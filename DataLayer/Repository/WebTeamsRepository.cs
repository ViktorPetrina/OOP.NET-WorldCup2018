using DataLayer.Model;
using Newtonsoft.Json;
using System.Net;

namespace DataLayer.Repository
{
    public class WebTeamsRepository : IFootballRepository
    {
        private readonly string TEAMS_ENDPOINT;
        private readonly string COUNTRY_MATCHES_ENDPOINT;

        public WebTeamsRepository(string gender)
        {
            TEAMS_ENDPOINT = @"https://worldcup-vua.nullbit.hr/" + gender + @"/teams";
            COUNTRY_MATCHES_ENDPOINT = $"https://worldcup-vua.nullbit.hr/" + gender + @"/matches/country?fifa_code=";
        }

        public Task<List<GroupResult>> GetAllGroupResults()
        {
            throw new NotImplementedException();
        }

        public Task<List<Match>> GetAllMatches()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Player>> GetPlayersByFifaCode(string fifaCode, IProgress<int> progress)
        {
            string data = new WebClient().DownloadString(COUNTRY_MATCHES_ENDPOINT + fifaCode);
            List<Player> players = new List<Player>();

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new TypeOfEventConverter());
            settings.Converters.Add(new ParseStringConverter());
            settings.Converters.Add(new PositionConverter());
            
            Match match = new Match();
            if (data != null)
            {
               match = JsonConvert.DeserializeObject<List<Match>>(data, settings).First(); 
            }

            if (match.HomeTeam.FifaCode == fifaCode)
            {
                players.AddRange(match.HomeTeamStatistics.StartingEleven);
                players.AddRange(match.HomeTeamStatistics.Substitutes);
            }
            else
            {
                players.AddRange(match.AwayTeamStatistics.StartingEleven);
                players.AddRange(match.AwayTeamStatistics.Substitutes);
            }

            progress.Report(100);

            return players;
        }

        public Task<List<Team>> GetAllResults()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Team>> GetAllTeams(IProgress<int> progress)
        {
            string data = new WebClient().DownloadString(TEAMS_ENDPOINT);

            if (data is null)
            {
                throw new Exception("Provided JSON content is null.");
            }

            progress.Report(100);

            return JsonConvert.DeserializeObject<List<Team>>(data);
        }

        public async Task<List<Match>> GetMatchesByCountry(string fifaCode)
        {
            string data = new WebClient().DownloadString(COUNTRY_MATCHES_ENDPOINT + fifaCode);

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new TypeOfEventConverter());
            settings.Converters.Add(new ParseStringConverter());
            settings.Converters.Add(new PositionConverter());

            List<Match> matches;

            if (data != null)
            {
                matches = JsonConvert.DeserializeObject<List<Match>>(data, settings);

                if (matches != null)
                {
                    return matches;
                }
            }

            return new List<Match>();
        }
    }
}
