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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Size SMALL_WINDOW_SIZE = new Size(800, 600);
        private readonly Size MEDIUM_WINDOW_SIZE = new Size(1280, 720);
        private readonly Size LARGE_WINDOW_SIZE = new Size(1920, 1080);

        private IFootballRepository repo;
        private UserPreferences settingsPreferences;

        public MainWindow()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeUserPreferences();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            InitalizeRepository();
            InitializeTeams();
        }

        private async void InitializeTeams()
        {
            var preferences = PreferencesUtils.LoadPreferences();
            lblFavTeam.Content = preferences.FavouriteTeam?.ToString();

            List<Team> teams = await repo.GetAllTeams(new Progress<int>());
            teams.ToList().ForEach(team => cbTeams.Items.Add(team));
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
            Team team = new Team();
            if (cbTeams.SelectedItem is Team _team)
            {
                team = _team;
            }

            cbOpposingTeams.Items.Clear();

            var matches = await repo.GetMatchesByCountry(team.FifaCode);
            matches.Select(match =>
            {
                if (match.HomeTeam.FifaCode == team.FifaCode)
                    return match.AwayTeam;
                else
                    return match.HomeTeam;

            }).ToList().ForEach(t => cbOpposingTeams.Items.Add(t));
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
            var match = matches
                .FirstOrDefault(m =>
                    m.HomeTeam.FifaCode == team.FifaCode && m.AwayTeam.FifaCode == oppTeam.FifaCode ||
                    m.HomeTeam.FifaCode == oppTeam.FifaCode && m.AwayTeam.FifaCode == team.FifaCode); 


            if (match != null)
            {
                lblHomeTeamGoals.Content = match.HomeTeam.FifaCode == team.FifaCode ? 
                    match.HomeTeam.Goals.ToString() : match.AwayTeam.Goals.ToString();

                lblAwayTeamGoals.Content = match.AwayTeam.FifaCode == oppTeam.FifaCode ?
                    match.AwayTeam.Goals.ToString() : match.HomeTeam.Goals.ToString();
            }
        }

        private void FormClear()
        {
            cbOpposingTeams.SelectedItem = null;
            cbTeams.SelectedItem = null;
        }
    }
}