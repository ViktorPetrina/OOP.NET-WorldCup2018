﻿using DataLayer.Model;
using DataLayer.Repository;
using WinFormApp.Utilities;
using System.Data;
using System.Diagnostics;

namespace ViktorPetrina
{
    public partial class MainForm : Form
    {
        private const string GENERIC_NOT_SELECTED_ERROR = "A team and at least one player must be selected!";
        private const string EXIT_SAVE_PREFERENCES_MESSAGE = "Do you want to save selected preferences?";
        private const string EXIT_CONFIRMATION_MESSAGE = "Do you really want to exit?";
        private const string DEFAULT_IMAGE_PATH = @"{0}Resources\\Images\\default.png";
        private const string MAX_FAV_PLAYER_NUMBER_ERROR = "Max favourite player count is 3!";
        private const string PLAYER_ALREADY_ADDED_ERROR = "Can't add a player that is already favourite.";
        private const string PICTURE_ERROR_MESSAGE = "Player picture was changed or deleted";
        private const string API_ERROR_MESSAGE = "Api was unable to fetch required data, consider switching to json.";

        private IFootballRepository repo;
        private UserPreferences settingsPreferences;

        private bool preferencesSaved = true;
        private bool pictureChanged = false;
        private bool settingsClicked = false;
        private Player selectedPlayer;

        public MainForm()
        {
            Initialize();
        }

        private void cbTeams_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbTeams.SelectedItem is Team team)
            {
                try
                {
                    ShowTeam(team);
                    preferencesSaved = false;

                }
                catch
                {
                    MessageBox.Show(API_ERROR_MESSAGE, "Api error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (PreferencesUtils.PreferencesExist() && pictureChanged)
            {
                var preferences = PreferencesUtils.LoadPreferences();
                preferences.FavouritePlayers = lbFavPlayers.Items.Cast<Player>().ToList();
                PreferencesUtils.SavePrefrences(preferences);

                preferencesSaved = true;
                pictureChanged = false;
                return;
            }

            if (!FormValid() && !pictureChanged)
            {
                MessageBox.Show(GENERIC_NOT_SELECTED_ERROR, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PreferencesUtils.SavePrefrences(GetCombinedPreferences());
            preferencesSaved = true;
            pictureChanged = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (settingsClicked)
            {
                return;
            }

            if (!preferencesSaved)
            {
                DialogResult savePreferences = MessageBox.Show(
                        EXIT_SAVE_PREFERENCES_MESSAGE,
                        "Exit",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (FormValid() && savePreferences == DialogResult.Yes)
                {
                    PreferencesUtils.SavePrefrences(GetCombinedPreferences());
                }
            }

            DialogResult exit = MessageBox.Show(
                        EXIT_CONFIRMATION_MESSAGE,
                        "Exit",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

            if (exit != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            Environment.Exit(0);
        }

        private void btnChoosePlayerImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pictures|*.bmp;*.jpg;*.jpeg;*.png;|All files|*.*";
            ofd.InitialDirectory = Application.StartupPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedPlayer.ImagePath = ofd.FileName;
                pbPlayerImage.Image = Image.FromFile(selectedPlayer.ImagePath);
                pictureChanged = true;
            }
        }

        private void lbPlayers_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbPlayers.SelectedItem is Player player)
            {
                ShowPlayer(player);
                preferencesSaved = false;
                selectedPlayer = player;
            }
        }

        private void lbPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            lbPlayers_SelectedValueChanged(sender, e);

            if (lbPlayers.SelectedItem != null)
            {
                lbPlayers.DoDragDrop(lbPlayers.SelectedItem, DragDropEffects.Move);
            }

            if (e.Button == MouseButtons.Right)
            {
                int index = lbFavPlayers.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    lbFavPlayers.SelectedIndex = index;
                }
            }
        }

        private void openSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsClicked = true;
            Application.Restart();
        }

        private void lbFavPlayers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && lbFavPlayers.SelectedItem is Player player)
            {
                ShowPlayer(player);
                selectedPlayer = player;
            }
        }

        private void lbFavPlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Player)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
            
        }

        private void lbFavPlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (lbFavPlayers.Items.Count >= 3)
            {
                MessageBox.Show(
                    MAX_FAV_PLAYER_NUMBER_ERROR,
                    "Max favourite players.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            Player player = new Player();

            if (e.Data.GetData(typeof(Player)) is Player p) 
                player = p;
            else
                return;
            
            if (lbFavPlayers.Items.Contains(player))
            {
                MessageBox.Show(
                    PLAYER_ALREADY_ADDED_ERROR,
                    "Player already added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            lbFavPlayers.Items.Add(player);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbFavPlayers.SelectedItem != null)
            {
                lbFavPlayers.Items.Remove(lbFavPlayers.SelectedItem);
            }
        }

        private void Initialize()
        {
            InitializeUserPreferences();
            InitalizeRepository();
            InitializeLanguage();
            InitializeComponent();
            InitializeDefaultImage();
            InitializePreferences();
            InitializeTeams();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private async void InitializeTeams()
        {
            IProgress<int> progress = new Progress<int>(value => progressBar.Value = value);
            List<Team> teams = await repo.GetAllTeams(progress);
            teams.Sort((a, b) => a.FifaCode.CompareTo(b.FifaCode));
            cbTeams.Items.AddRange(teams.ToArray());
        }

        private void InitializePreferences()
        {
            if (!PreferencesUtils.PreferencesExist())
            {
                return;
            }

            var preferences = PreferencesUtils.LoadPreferences();

            lblFavTeam.Text = preferences.FavouriteTeam?.Country;
            preferences.FavouritePlayers?.ToList().ForEach(player => lbFavPlayers.Items.Add(player));
        }

        private void InitalizeRepository()
        {
            if (settingsPreferences.DataSource == UserPreferences.SourceType.API &&
                settingsPreferences.TeamGender == UserPreferences.Gender.Male)
            {
                repo = new WebTeamsRepository("men");
            }
            else if (settingsPreferences.DataSource == UserPreferences.SourceType.API &&
                settingsPreferences.TeamGender == UserPreferences.Gender.Female)
            {
                repo = new WebTeamsRepository("women");
            }
            else if (settingsPreferences.DataSource == UserPreferences.SourceType.Json &&
                settingsPreferences.TeamGender == UserPreferences.Gender.Female)
            {
                repo = new FileTeamsRepository("women");
            }
            else
            {
                repo = new FileTeamsRepository("men");
            }
        }

        private void InitializeDefaultImage()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            string fullPath = string.Format(
                DEFAULT_IMAGE_PATH,
                Path.GetFullPath(Path.Combine(basePath, @"..\..\..\")));

            pbPlayerImage.Image = Image.FromFile(fullPath);
        }

        private void InitializeLanguage()
        {
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

        private void InitializeUserPreferences()
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog();

            settingsPreferences = (form.Tag as UserPreferences);
        }

        private void ShowPlayer(Player player)
        {
            if (player == null)
            {
                return;
            }

            FormClear();

            lblPlayerName.Text = player.Name;
            lblPlayerNumber.Text = player.ShirtNumber.ToString();
            lblPlayerIsCaptain.Text = player.Captain ? "Da" : "Ne";

            if (PreferencesUtils.PreferencesExist() && PreferencesUtils.LoadPreferences().FavouritePlayers != null)
            {
                lblPlayerIsFavourite.Text = PreferencesUtils.LoadPreferences().FavouritePlayers
                    .Any(p => p.Name.Equals(player.Name)) ? "Da" : "Ne";
            }

            if (player.ImagePath != null)
            {
                try
                {
                    pbPlayerImage.Image = Image.FromFile(player.ImagePath);
                }
                catch
                {
                    MessageBox.Show(PICTURE_ERROR_MESSAGE, "Picture error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormClear()
        {
            lblPlayerName.Text = "";
            lblPlayerNumber.Text = "";
            lblPlayerIsCaptain.Text = "";
            lblPlayerIsFavourite.Text = "";
            InitializeDefaultImage();
        }

        private async void ShowTeam(Team team)
        {
            string fifaCode = team.FifaCode;
            IProgress<int> progress = new Progress<int>(value => progressBar.Value = value);

            progressBar.Value = 0;
            IList<Player> playerList = await repo.GetPlayersByFifaCode(fifaCode, progress);

            lbPlayers.Items.Clear();
            lbPlayers.Items.AddRange(playerList.ToArray());
        }

        private bool FormValid()
            => cbTeams.SelectedItem is Team && lbPlayers.SelectedItems.Count > 0 || lbFavPlayers.Items.Count != 0;

        private UserPreferences GetCombinedPreferences()
            => new UserPreferences
            {
                DataSource = settingsPreferences.DataSource,
                PreferedLanguage = settingsPreferences.PreferedLanguage,
                TeamGender = settingsPreferences.TeamGender,
                FavouriteTeam = cbTeams.SelectedItem as Team,
                FavouritePlayers = GetFavouritePlayers()
            };

        private List<Player> GetFavouritePlayers()
        {
            var players = new List<Player>();

            players.AddRange(lbPlayers.SelectedItems.Cast<Player>().ToList());
            foreach (var player in lbFavPlayers.Items)
            {
                var newPlayer = player as Player;
                if (!players.ToList().Exists(p => p.Equals(player)) && newPlayer != null)
                {
                    players.Add(newPlayer);
                }
            }

            return players;
        }
    }
}
