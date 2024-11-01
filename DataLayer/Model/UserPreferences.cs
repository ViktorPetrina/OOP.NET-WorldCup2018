
using System.Drawing;

namespace DataLayer.Model
{
    public class UserPreferences
    {
        public Gender TeamGender { get; set; }
        public Language PreferedLanguage { get; set; }
        public SourceType DataSource { get; set; }
        public Team? FavouriteTeam { get; set; }
        public IList<Player>? FavouritePlayers { get; set; }
        public WindowSizeType WindowSize { get; set; }

        public enum Gender
        {
            Male, Female
        }

        public enum Language 
        { 
            English, Croatian 
        }
        
        public enum SourceType
        {
            Json, API
        }

        public enum WindowSizeType
        {
            Small, Medium, Large, Fullscreen
        }
    }
}
