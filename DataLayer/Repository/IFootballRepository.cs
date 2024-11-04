using DataLayer.Model;

namespace DataLayer.Repository
{
    public interface IFootballRepository
    {
        Task<List<Match>> GetAllMatches();
        Task<List<Match>> GetMatchesByCountry(string fifaCode);
        Task<List<Player>> GetPlayersByFifaCode(string fifaCode, IProgress<int> progress);
        Task<List<Team>> GetAllTeams(IProgress<int> progress);
        Task<List<Team>> GetAllResults();
        Task<List<GroupResult>> GetAllGroupResults();
    }
}
