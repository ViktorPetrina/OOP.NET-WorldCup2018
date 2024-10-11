using DataLayer.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public static class FileManager
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
            return JsonConvert.DeserializeObject<UserPreferences>(File.ReadAllText(GetFilePath()));
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
