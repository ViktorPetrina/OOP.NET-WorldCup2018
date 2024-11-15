using DataLayer.Model;
using DataLayer.Repository;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinFormApp.Utilities;

// TODO:
// dodati animacije kod prikaza reprezentacija i timova

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly Size SMALL_WINDOW_SIZE = new Size(600, 400);
        private readonly Size MEDIUM_WINDOW_SIZE = new Size(1080, 620);
        private readonly Size LARGE_WINDOW_SIZE = new Size(1720, 880);

        private readonly string TEAM_DETAILS_TEMPLATE = 
            "{0}\nGames played: {1}\nWins: {2}\nLosses: {3}\nDraws: {4}\nGoals for: {5}\nGoals against: {6}\nGoal differencial: {7}";

        private readonly string PLAYER_DETAILS_TEMPLATE =
            "Name: {0}\nShirt number: {1}\nPosition: {2}\nCaptain: {3}Goals: {3}\nYellow cards: {4}";

        private IFootballRepository repo;
        private UserPreferences settingsPreferences;

        public MainWindow()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeUserPreferences();
            InitializeCulture();
            InitializeComponent();
            InitializeScreenSize();
            InitalizeRepository();
            InitializeTeams();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Background = Brushes.Gray;
        }

        private void InitializeCulture()
        {
            if (settingsPreferences.PreferedLanguage.Equals(UserPreferences.Language.English))
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            }    
            else 
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hr");
            }
        }

        private void InitializeScreenSize()
        {
            switch (settingsPreferences.WindowSize)
            {
                case UserPreferences.WindowSizeType.Small:
                    SetWindowSize(SMALL_WINDOW_SIZE);
                    break;
                case UserPreferences.WindowSizeType.Medium:
                    SetWindowSize(MEDIUM_WINDOW_SIZE);
                    break;
                case UserPreferences.WindowSizeType.Large: 
                    SetWindowSize(LARGE_WINDOW_SIZE);
                    break;
                case UserPreferences.WindowSizeType.Fullscreen:
                    WindowState = WindowState.Maximized;
                    break;
            }
        }

        private void SetWindowSize(Size size)
        {
            Width = size.Width;
            Height = size.Height;
        }

        private async void InitializeTeams()
        {
            var preferences = PreferencesUtils.LoadPreferences();
            lblFavTeam.Content = preferences.FavouriteTeam?.ToString();

            List<Team> teams = await repo.GetAllTeams(new Progress<int>());
            teams.Sort((t1, t2) => t1.Country.CompareTo(t2.Country));
            teams.ForEach(team => cbTeams.Items.Add(team));
        }

        private void InitializeUserPreferences()
        {
            SettingsWindow window = new SettingsWindow();
            window.ShowDialog();

            if (window.Tag is UserPreferences preferences)
            {
                settingsPreferences = preferences;
            }
        }

        private void InitalizeRepository()
        {
            if (settingsPreferences.TeamGender == UserPreferences.Gender.Male)
            {
                repo = new WebTeamsRepository("men");
            }
            else
            {
                repo = new WebTeamsRepository("women");
            }
        }

        private async void cbTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblHomeTeamGoals.Content = String.Empty;
            lblAwayTeamGoals.Content = String.Empty;

            Team team = new Team();
            if (cbTeams.SelectedItem is Team _team)
            {
                team = _team;
            }

            cbOpposingTeams.Items.Clear();
            cbPlayers.Items.Clear();

            var matches = await repo.GetMatchesByCountry(team.FifaCode);
            matches.Select(match =>
            {
                if (match.HomeTeam.FifaCode == team.FifaCode)
                    return match.AwayTeam;
                else
                    return match.HomeTeam;

            }).ToList().ForEach(t => cbOpposingTeams.Items.Add(t));

            var players = await repo.GetPlayersByFifaCode(team.FifaCode, new Progress<int>());
            players.ForEach(player => cbPlayers.Items.Add(player));
        }

        private async void btnShowTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            Result? result;
            if (cbTeams.SelectedItem is Team team && ((Button)e.Source).Name == btnShowTeamDetails.Name)
            {
                var results = await repo.GetAllResults();
                if (results is List<Result>)
                {
                    result = results
                    .ToList()
                    .FirstOrDefault(r => r.Country == team.Country);

                    if (result != null)
                    {
                        ShowTeamDetails(result);
                    }
                }
            }

            if (cbOpposingTeams.SelectedItem is TeamMini teamMini && ((Button)e.Source).Name == btnShowOppTeamDetails.Name)
            {
                var results = await repo.GetAllResults();
                if (results is List<Result>)
                {
                    result = results
                    .ToList()
                    .FirstOrDefault(r => r.Country == teamMini.Country);

                    if (result != null)
                    {
                        ShowTeamDetails(result);
                    }
                }
            }
        }

        private async void cbOpposingTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Team team = new Team();
            if (cbTeams.SelectedItem is Team _team)
            {
                team = _team;
            }

            TeamMini oppTeam = new TeamMini();
            if (cbOpposingTeams.SelectedItem is TeamMini t)
            {
                oppTeam = t;
            }
            
            var matches = await repo.GetMatchesByCountry(team.FifaCode);

            await Task.Run(() =>
            {
                var match = matches
                    .FirstOrDefault(m =>
                        m.HomeTeam.FifaCode == team.FifaCode && m.AwayTeam.FifaCode == oppTeam.FifaCode ||
                        m.HomeTeam.FifaCode == oppTeam.FifaCode && m.AwayTeam.FifaCode == team.FifaCode);

                if (match != null)
                {
                    Application.Current.Dispatcher.BeginInvoke(() =>
                    {
                        lblHomeTeamGoals.Content = match.HomeTeam.FifaCode == team.FifaCode ?
                            match.HomeTeam.Goals.ToString() : match.AwayTeam.Goals.ToString();

                        lblAwayTeamGoals.Content = match.AwayTeam.FifaCode == oppTeam.FifaCode ?
                            match.AwayTeam.Goals.ToString() : match.HomeTeam.Goals.ToString();
                    });
                }
            });
        }

        private void FormClear()
        {
            cbOpposingTeams.SelectedItem = null;
            cbTeams.SelectedItem = null;
        }

        // dodati animaciju u trajanju od 0.5 sekundi uz dizanje prozora
        private void ShowTeamDetails(Result result)
        {
            var message = String.Format(
                TEAM_DETAILS_TEMPLATE,
                result,
                result.GamesPlayed,
                result.Wins,
                result.Losses,
                result.Draws,
                result.GoalsFor,
                result.GoalsAgainst,
                result.GoalDifferential);

            MessageBox.Show(message, $"{result.Country} details", MessageBoxButton.OK);
        }

        // dodati i ovom prozoru animaciju u trajanju od 0.3 sekunde koja se razlikuje od ove za tim
        private void ShowPlayerDetails(Player player)
        {
            if (PreferencesUtils.LoadPreferences().FavouritePlayers?.Count > 0)
            {
                Player? player_ = PreferencesUtils
                    .LoadPreferences()?
                    .FavouritePlayers?
                    .FirstOrDefault(p => p.Name.Equals(player.Name));

                if (player_ != null)
                    player.ImagePath = player_.ImagePath;
            }

            new PlayerDetailsWindow(player, 1, 1).ShowDialog();
        }

        private void btnShowPlayerDetails_Click(object sender, RoutedEventArgs e)
        {
            if (cbPlayers.SelectedItem is Player player) 
                ShowPlayerDetails(player);
        }

        private void btnPickFavTeam_Click(object sender, RoutedEventArgs e)
        {
            if (cbTeams.SelectedItem is Team team)
            {
                var prefs = PreferencesUtils.LoadPreferences();
                prefs.FavouriteTeam = team;
                lblFavTeam.Content = team.Country;
                PreferencesUtils.SavePrefrences(prefs);
            }
        }
    }
}