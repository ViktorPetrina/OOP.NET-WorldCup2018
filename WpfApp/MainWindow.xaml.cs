using DataLayer.Model;
using DataLayer.Repository;
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
    }
}