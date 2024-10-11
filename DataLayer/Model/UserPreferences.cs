using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class UserPreferences
    {
        public Gender TeamGender { get; set; }
        public Language PreferedLanguage { get; set; }
        public SourceType DataSource { get; set; }
        public Team? FavouriteTeam { get; set; }
        public IList<Player>? FavouritePlayers { get; set; }

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

        
    }

    
}
