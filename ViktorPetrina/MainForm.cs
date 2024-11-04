using DataLayer.Model;
using DataLayer.Repository;
using WinFormApp.Utilities;
using System.Data;

// TODO: eventualno popraviti darg drop multiple igraca

namespace ViktorPetrina
{
    public partial class MainForm : Form
    {
        private const string GENERIC_NOT_SELECTED_ERROR = "A team and at least one player must be selected!";
        private const string EXIT_CONFIRMATION_MESSAGE = "Do you want to save selected preferences?";
        private const string DEFAULT_IMAGE_PATH = @"{0}Resources\\Images\\default.png";
        private const string MAX_FAV_PLAYER_NUMBER_ERROR = "Max favourite player count is 3!";
        private const string PLAYER_ALREADY_ADDED_ERROR = "Can't add a player that is already favourite.";

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

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await ShowAllTeams();

            if (!PreferencesUtils.PreferencesExist())
            {
                return;
            }

            var preferences = PreferencesUtils.LoadPreferences();

            lblFavTeam.Text = preferences.FavouriteTeam?.Country;
            preferences.FavouritePlayers?.ToList().ForEach(player => lbFavPlayers.Items.Add(player));
        }

        private async Task ShowAllTeams()
        {
            IProgress<int> progress = new Progress<int>(value => progressBar.Value = value);
            List<Team> teams = await repo.GetAllTeams(progress);
            cbTeams.Items.AddRange(teams.ToArray());
        }

        private void cbTeams_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowTeam(cbTeams.SelectedItem as Team);

            preferencesSaved = false;
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
            if (preferencesSaved || settingsClicked)
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
            var player = lbPlayers.SelectedItem as Player;
            ShowPlayer(player);

            preferencesSaved = false;
            selectedPlayer = player;
        }

        private void lbFavPlayers_SelectedValueChanged(object sender, EventArgs e)
        {

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

        private void lbPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbPlayers.SelectedItems.Count > 0)
            {
                List<Player> selectedItems = new List<Player>(); 
                foreach (var player in lbPlayers.SelectedItems) 
                { 
                    selectedItems.Add(player as Player); 
                }

                lbPlayers.DoDragDrop(lbPlayers.SelectedItems, DragDropEffects.Move);
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
            if (e.Button == MouseButtons.Left)
            {
                var player = lbFavPlayers.SelectedItem as Player;
                ShowPlayer(player);
                selectedPlayer = player;
            }
        }

        private void lbFavPlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<Player>)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lbFavPlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(IEnumerable<Player>)) || lbFavPlayers.Items.Count >= 3)
            {
                MessageBox.Show(
                    MAX_FAV_PLAYER_NUMBER_ERROR, 
                    "Max player number reached", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                return;
            }
            
            var players = e.Data.GetData(typeof(List<Player>)) as List<Player>;

            if (!lbFavPlayers.Items.Contains(players))
            {
                MessageBox.Show(
                    PLAYER_ALREADY_ADDED_ERROR,
                    "Player already added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            foreach (var player in players)
            {
                lbFavPlayers.Items.Add(player);
            }
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
            StartPosition = FormStartPosition.CenterScreen;
            InitalizeRepository();
            InitializeLanguage();
            InitializeComponent();
            InitializeDefaultImage();
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
            FormClear();

            lblPlayerName.Text = player.Name;
            lblPlayerNumber.Text = player.ShirtNumber.ToString();
            lblPlayerIsCaptain.Text = player.Captain ? "Da" : "Ne";

            if (PreferencesUtils.PreferencesExist() && PreferencesUtils.LoadPreferences().FavouritePlayers != null)
            {
                lblPlayerIsFavourite.Text = PreferencesUtils.LoadPreferences()
                    .FavouritePlayers.Contains(player) ? "Da" : "Ne";
            }

            if (player.ImagePath != null)
            {
                pbPlayerImage.Image = Image.FromFile(player.ImagePath);
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
