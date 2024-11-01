using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WinFormApp.Utilities;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private readonly IDictionary<RadioButton, UserPreferences.WindowSizeType> radioButtonSizes; 
        private const string FORM_NOT_VALID_MESSAGE = "Each option has to be checked.";

        public SettingsWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            radioButtonSizes = new Dictionary<RadioButton, UserPreferences.WindowSizeType>
            {
                { rbtnSmallSize, UserPreferences.WindowSizeType.Small },
                { rbtnMidSize, UserPreferences.WindowSizeType.Medium },
                { rbtnBigSize, UserPreferences.WindowSizeType.Large },
                { rbtnFullscreen, UserPreferences.WindowSizeType.Fullscreen }
            };
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!FormValid())
            {
                MessageBox.Show(FORM_NOT_VALID_MESSAGE, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Tag = GetPreferencesFromUser();

            if (PreferencesUtils.PreferencesExist())
            {
                var preferences = PreferencesUtils.LoadPreferences();
                var userPreferences = GetPreferencesFromUser();

                preferences.WindowSize = userPreferences.WindowSize;
                preferences.TeamGender = userPreferences.TeamGender;
                preferences.PreferedLanguage = userPreferences.PreferedLanguage;

                PreferencesUtils.SavePrefrences(preferences);
            }
            else
            {
                PreferencesUtils.SavePrefrences(GetPreferencesFromUser());
            }

            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private UserPreferences GetPreferencesFromUser()
        {
            var preferences = new UserPreferences();

            if (rbtnMale.IsChecked.HasValue)
            {
                preferences.TeamGender = rbtnMale.IsChecked.Value ? UserPreferences.Gender.Male : UserPreferences.Gender.Female;
            }

            if (rbtnEnglish.IsChecked.HasValue)
            {
                preferences.PreferedLanguage = rbtnEnglish.IsChecked.Value ? UserPreferences.Language.English : UserPreferences.Language.Croatian;
            }

            preferences.WindowSize = radioButtonSizes.FirstOrDefault(btn => btn.Key.IsChecked == true).Value;

            return preferences;
        }

        private bool FormValid()
        {
            return 
                (rbtnMale.IsChecked.Value || rbtnFemale.IsChecked.Value) &&
                (rbtnCroatian.IsChecked.Value || rbtnEnglish.IsChecked.Value) &&
                (rbtnSmallSize.IsChecked.Value || rbtnMidSize.IsChecked.Value || rbtnBigSize.IsChecked.Value || rbtnFullscreen.IsChecked.Value);
        }
    }
}
