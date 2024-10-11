using DataLayer.Repository;
using DataLayer.Model;

namespace ViktorPetrina
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            new MainForm(GetPreferencesFromUser()).Show();
            Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Application.Exit();

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var preferences = FileManager.LoadPreferences();

            rbtnMale.Checked = preferences.TeamGender.Equals(UserPreferences.Gender.Male);
            rbtnFemale.Checked = !rbtnMale.Checked;

            rbtnEnglish.Checked = preferences.PreferedLanguage.Equals(UserPreferences.Language.English);
            rbtnCroatian.Checked = !rbtnEnglish.Checked;

            rbtnApi.Checked = preferences.DataSource.Equals(UserPreferences.SourceType.API);
            rbtnJson.Checked = !rbtnApi.Checked;

        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //FileManager.SavePrefrences(GetPreferencesFromUser());
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
    }
}
