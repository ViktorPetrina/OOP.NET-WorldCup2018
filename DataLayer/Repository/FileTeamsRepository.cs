using DataLayer.Model;
using Newtonsoft.Json;

namespace DataLayer.Repository
{
    public class FileTeamsRepository : IFootballRepository
    {
        private readonly string DATA_PATH;

        public FileTeamsRepository(string gender)
        {
            DATA_PATH = @"{0}Data\worldcup.sfg.io\" + gender;
        }

        public Task<List<GroupResult>> GetAllGroupResults()
        {
            throw new NotImplementedException();
        }

        public Task<List<Match>> GetAllMatches()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Team>> GetAllTeams(IProgress<int> progress)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            string fullPath = string.Format(
                DATA_PATH,
                Path.GetFullPath(Path.Combine(basePath, @"..\..\..\")));

            string data = File.ReadAllText(fullPath + "\\teams.json");

            if (data is null)
            {
                throw new Exception("Provided JSON content is null.");
            }

            progress.Report(100);

            return JsonConvert.DeserializeObject<List<Team>>(data);
        }

        public Task<List<Match>> GetMatchesByCountry(string fifaCode)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Player>> GetPlayersByFifaCode(string fifaCode, IProgress<int> progress)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            string fullPath = string.Format(
                DATA_PATH,
                Path.GetFullPath(Path.Combine(basePath, @"..\..\..\")));

            string data = File.ReadAllText(fullPath + "\\matches.json");

            List<Player> players = new List<Player>();

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new TypeOfEventConverter());
            settings.Converters.Add(new ParseStringConverter());
            settings.Converters.Add(new PositionConverter());

            var matches = JsonConvert.DeserializeObject<List<Match>>(data, settings);
            
            var match = matches.First(m => m.HomeTeam.FifaCode == fifaCode || m.AwayTeam.FifaCode == fifaCode);

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

            return players;
        }

        public Task<List<Result>> GetAllResults()
        {
            throw new NotImplementedException();
        }
    }
}
