using DataLayer.Model;
using DataLayer.Utilities;
using System.Text;

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

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("form is closing", "", MessageBoxButtons.OK);
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
        
    }
}
