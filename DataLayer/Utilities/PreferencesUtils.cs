using DataLayer.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Utilities
{
    public static class PreferencesUtils
    {
        private const string APP_NAME = "WinFormApp"; // promjeniti poslje u Application.ProductName
        private const string FILE_NAME = "preferences.json";

        public static void SavePrefrences(UserPreferences preferences)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter());
            settings.Converters.Add(new ParseStringConverter());

            string json = JsonConvert.SerializeObject(preferences, Formatting.Indented, settings);
            File.WriteAllText(GetFilePath(), json);
        }

        public static UserPreferences LoadPreferences()
        {
            if (!File.Exists(GetFilePath()))
            {
                throw new Exception("Preferences do not exist.");
            }

            return JsonConvert.DeserializeObject<UserPreferences>(File.ReadAllText(GetFilePath()));
        }

        public static bool PreferencesExist()
        {
            return File.Exists(GetFilePath());
        }

        private static string GetFilePath()
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appFolder = Path.Combine(folderPath, APP_NAME);
            Directory.CreateDirectory(appFolder);

            return Path.Combine(appFolder, FILE_NAME);
        }


    }
}
