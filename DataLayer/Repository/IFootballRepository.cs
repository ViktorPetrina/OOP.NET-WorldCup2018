using DataLayer.Model;

namespace DataLayer.Repository
{
    public interface IFootballRepository
    {
        List<Match> GetAllMatches();
        List<Match> GetMatchesByCountry(string fifaCode);
        Task<List<Player>> GetPlayersByFifaCode(string fifaCode, IProgress<int> progress);
        Task<List<Team>> GetAllTeams(IProgress<int> progress);
        List<Team> GetAllResults();
        List<GroupResult> GetAllGroupResults();
    }
}
