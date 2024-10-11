using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class GroupResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("letter")]
        public string? Letter { get; set; }

        [JsonProperty("ordered_teams")]
        public List<Team>? OrderedTeams { get; set; }
    }
}
