using DataLayer;
using DataLayer.Model;
using DataLayer.Repository;
using DataLayer.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO: sredi da su rijeci lokaliziranje, sredi da igraci imaju slike, pogledaj zasto su nekad obrnuti timovi i popravi

namespace ViktorPetrina
{
    public partial class MainForm : Form
    {
        private const string GENERIC_NOT_SELECTED_ERROR = "A team and at least one player must be selected!";
        private const string EXIT_CONFIRMATION_MESSAGE = "Do you want to save selected preferences?";

        private IFootballRepository menRepo;
        private UserPreferences settingsPreferences;

        private bool preferencesSaved = true;

        public MainForm(UserPreferences preferences_)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            menRepo = new MenTeamsRepository();
            settingsPreferences = preferences_;
            SetCulture("en");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<Team> teams = menRepo.GetAllTeams();
            cbTeams.Items.AddRange(teams.ToArray());

            if (!PreferencesUtils.PreferencesExist())
            {
                return;
            }

            var preferences = PreferencesUtils.LoadPreferences();

            // izvadi to u konstantu ili u nesto vezano uz resurse i jezike...

            lblFavTeam.Text = preferences.FavouriteTeam?.Country;
            preferences.FavouritePlayers?.ToList().ForEach(player => lbFavPlayers.Items.Add(player));
        }

        private void cbTeams_SelectedValueChanged(object sender, EventArgs e)
        {
            string fifaCode = (cbTeams.SelectedItem as Team).FifaCode;
            IList<Player> playerList = menRepo.GetPlayersByFifaCode(fifaCode);

            lbPlayers.Items.Clear();
            lbPlayers.Items.AddRange(playerList.ToArray());

            preferencesSaved = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!FormValid())
            {
                MessageBox.Show(GENERIC_NOT_SELECTED_ERROR, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            preferencesSaved = true;
            PreferencesUtils.SavePrefrences(GetCombinedPreferences());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!preferencesSaved && MessageBox.Show(EXIT_CONFIRMATION_MESSAGE, "Exit",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            //    == DialogResult.Yes && FormValid())
            //{
            //    PreferencesUtils.SavePrefrences(GetCombinedPreferences());
            //}

            //Application.Exit();
        }

        private UserPreferences GetCombinedPreferences()
            => new UserPreferences
            {
                DataSource = settingsPreferences.DataSource,
                PreferedLanguage = settingsPreferences.PreferedLanguage,
                TeamGender = settingsPreferences.TeamGender,
                FavouriteTeam = cbTeams.SelectedItem as Team,
                FavouritePlayers = lbPlayers.SelectedItems.Cast<Player>().ToList()
            };

        private bool FormValid() => cbTeams.SelectedItem is Team && lbPlayers.SelectedItems.Count > 0;

        private void lbPlayers_SelectedValueChanged(object sender, EventArgs e)
        {
            lblPlayerName.Text = "Ime: " + (lbPlayers.SelectedItem as Player).Name;
            lblPlayerNumber.Text = "Broj: " + (lbPlayers.SelectedItem as Player).ShirtNumber.ToString();
            lblPlayerIsCaptain.Text = (lbPlayers.SelectedItem as Player).Captain ? "Kapetan: Da" : "Kapetan: Ne";

            if (PreferencesUtils.PreferencesExist())
            {
                lblPlayerIsFavourite.Text = PreferencesUtils.LoadPreferences()
                    .FavouritePlayers.Contains(lbPlayers.SelectedItem as Player) ? "Da" : "Ne";
            }

            preferencesSaved = false;
        }

        private void SetCulture(string lang)
        {
            var culture = new CultureInfo(lang);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            Controls.Clear();
            InitializeComponent();
            MainForm_Load(this, new EventArgs());
        }

        private void btnChangeCulture_Click(object sender, EventArgs e)
        {
            if (Thread.CurrentThread.CurrentCulture.Name == "hr")
            {
                SetCulture("en");
            }
            else
            {
                SetCulture("hr");
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!preferencesSaved && MessageBox.Show(EXIT_CONFIRMATION_MESSAGE, "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes && FormValid())
            {
                PreferencesUtils.SavePrefrences(GetCombinedPreferences());
            }
            else
            {
                Close();
            }

            Application.Exit();
        }
    }
}
