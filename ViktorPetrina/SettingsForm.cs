using WinFormApp.Utilities;
using DataLayer.Model;

namespace ViktorPetrina
{
    public partial class SettingsForm : Form
    {
        private const string FORM_NOT_VALID_MESSAGE = "Each option has to be checked.";

        public SettingsForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!FormValid())
            {
                MessageBox.Show(FORM_NOT_VALID_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tag = GetPreferencesFromUser();

            if (PreferencesUtils.PreferencesExist())
            {
                var preferences = PreferencesUtils.LoadPreferences();
                var userPreferences = GetPreferencesFromUser();

                preferences.DataSource = userPreferences.DataSource;
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

        private void btnCancel_Click(object sender, EventArgs e) => Application.Exit();

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (!PreferencesUtils.PreferencesExist())
            {
                return;
            }

            var preferences = PreferencesUtils.LoadPreferences();

            rbtnMale.Checked = preferences.TeamGender.Equals(UserPreferences.Gender.Male);
            rbtnFemale.Checked = !rbtnMale.Checked;

            rbtnEnglish.Checked = preferences.PreferedLanguage.Equals(UserPreferences.Language.English);
            rbtnCroatian.Checked = !rbtnEnglish.Checked;

            rbtnApi.Checked = preferences.DataSource.Equals(UserPreferences.SourceType.API);
            rbtnJson.Checked = !rbtnApi.Checked;

        }

        private UserPreferences GetPreferencesFromUser()
            => new UserPreferences
            {
                TeamGender = rbtnMale.Checked ?
                UserPreferences.Gender.Male : UserPreferences.Gender.Female,

                PreferedLanguage = rbtnEnglish.Checked ?
                UserPreferences.Language.English : UserPreferences.Language.Croatian,

                DataSource = rbtnApi.Checked ?
                    UserPreferences.SourceType.API : UserPreferences.SourceType.Json
            };

        private bool FormValid()
            => rbtnMale.Checked || rbtnFemale.Checked &&
               rbtnCroatian.Checked || rbtnEnglish.Checked &&
               rbtnApi.Checked || rbtnJson.Checked;

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnConfirm_Click(sender, e);
                    break;

                case Keys.Escape:
                    btnCancel_Click(sender, e);
                    break;
            }
        }
    }
}
