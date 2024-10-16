using DataLayer;
using DataLayer.Model;
using DataLayer.Repository;
using WinFormApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp.Model;

// TODO:
// sredi da igraci imaju slike

namespace ViktorPetrina
{
    public partial class MainForm : Form
    {
        private const string GENERIC_NOT_SELECTED_ERROR = "A team and at least one player must be selected!";
        private const string EXIT_CONFIRMATION_MESSAGE = "Do you want to save selected preferences?";

        private IFootballRepository menRepo;
        private UserPreferences settingsPreferences;

        private bool preferencesSaved = true;

        public MainForm()
        {
            InitializeComponent();

            SettingsForm form = new SettingsForm();
            form.ShowDialog();

            settingsPreferences = (form.Tag as UserPreferences);

            StartPosition = FormStartPosition.CenterScreen;
            menRepo = new MenTeamsRepository();

            switch (settingsPreferences.PreferedLanguage)
            {
                case UserPreferences.Language.English:
                    FormUtils.SetCulture("en");
                    break;
                case UserPreferences.Language.Croatian:
                    FormUtils.SetCulture("hr");
                    break;
                default:
                    throw new Exception("Not supported language.");
            }
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

            lblFavTeam.Text = preferences.FavouriteTeam?.Country;
            preferences.FavouritePlayers?.ToList().ForEach(player => lbFavPlayers.Items.Add(player));
        }

        private void cbTeams_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowTeam(cbTeams.SelectedItem as Team);

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
            if (preferencesSaved)
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                EXIT_CONFIRMATION_MESSAGE,
                "Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (FormValid() && result == DialogResult.Yes)
            {
                PreferencesUtils.SavePrefrences(GetCombinedPreferences());
            }

            Environment.Exit(0);
        }

        private void lbPlayers_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowPlayer(lbPlayers.SelectedItem as Player);

            preferencesSaved = false;
        }

        private void lbFavPlayers_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowPlayer(lbFavPlayers.SelectedItem as Player);
        }

        private void ShowPlayer(Player player)
        {
            lblPlayerName.Text = player.Name;
            lblPlayerNumber.Text = player.ShirtNumber.ToString();
            lblPlayerIsCaptain.Text = player.Captain ? "Da" : "Ne";

            if (PreferencesUtils.PreferencesExist())
            {
                lblPlayerIsFavourite.Text = PreferencesUtils.LoadPreferences()
                    .FavouritePlayers.Contains(player) ? "Da" : "Ne";
            }
        }

        private void ShowTeam(Team team)
        {
            string fifaCode = team.FifaCode;
            IList<Player> playerList = menRepo.GetPlayersByFifaCode(fifaCode);

            lbPlayers.Items.Clear();
            lbPlayers.Items.AddRange(playerList.ToArray());
        }

        private bool FormValid() => cbTeams.SelectedItem is Team && lbPlayers.SelectedItems.Count > 0;

        private UserPreferences GetCombinedPreferences()
            => new UserPreferences
            {
                DataSource = settingsPreferences.DataSource,
                PreferedLanguage = settingsPreferences.PreferedLanguage,
                TeamGender = settingsPreferences.TeamGender,
                FavouriteTeam = cbTeams.SelectedItem as Team,
                FavouritePlayers = lbPlayers.SelectedItems.Cast<Player>().ToList()
            };
    }
}
