﻿using DataLayer;
using DataLayer.Model;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViktorPetrina
{
    public partial class MainForm : Form
    {
        private const string GENERIC_NOT_SELECTED_ERROR = "A team and at least one player must be selected!";
        private const string EXIT_CONFIRMATION_MESSAGE = "Do you want to save selected preferences?";

        private IFootballRepository menRepo;
        private UserPreferences settingsPreferences;

        public MainForm(UserPreferences preferences_)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            menRepo = new MenTeamsRepository();
            settingsPreferences = preferences_;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<Team> teams = menRepo.GetAllTeams();
            cbTeams.Items.AddRange(teams.ToArray());

            var preferences = FileManager.LoadPreferences();

            // izvadi to u konstantu ili u nesto vezano uz resurse i jezike...
            lblFavTeam.Text = $"Omiljena reprezentacija: {preferences.FavouriteTeam?.Country}";
            preferences.FavouritePlayers?.ToList().ForEach(player => lbFavPlayers.Items.Add(player));
        }

        private void cbTeams_SelectedValueChanged(object sender, EventArgs e)
        {
            string fifaCode = (cbTeams.SelectedItem as Team).FifaCode;
            IList<Player> playerList = menRepo.GetPlayersByFifaCode(fifaCode);

            lbPlayers.Items.Clear();
            lbPlayers.Items.AddRange(playerList.ToArray());
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!FormValid())
            {
                MessageBox.Show(GENERIC_NOT_SELECTED_ERROR, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FileManager.SavePrefrences(GetPreferences());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(EXIT_CONFIRMATION_MESSAGE, "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes && FormValid())
            {
                FileManager.SavePrefrences(GetPreferences());
            }

            Application.Exit();
        }

        private UserPreferences GetPreferences()
            => new UserPreferences
            {
                DataSource = settingsPreferences.DataSource,
                PreferedLanguage = settingsPreferences.PreferedLanguage,
                TeamGender = settingsPreferences.TeamGender,
                FavouriteTeam = cbTeams.SelectedItem as Team,
                FavouritePlayers = lbPlayers.SelectedItems.Cast<Player>().ToList()
            };

        private bool FormValid() => cbTeams.SelectedItem is Team && lbPlayers.SelectedItems.Count > 0;


    }
}
