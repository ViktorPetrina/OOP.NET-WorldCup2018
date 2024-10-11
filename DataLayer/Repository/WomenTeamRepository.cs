using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    internal class WomenTeamRepository : IFootballRepository
    {
        public List<GroupResult> GetAllGroupResults()
        {
            throw new NotImplementedException();
        }

        public List<Match> GetAllMatches()
        {
            throw new NotImplementedException();
        }

        public List<Team> GetAllResults()
        {
            throw new NotImplementedException();
        }

        public List<Team> GetAllTeams()
        {
            throw new NotImplementedException();
        }

        public List<Match> GetMatchesByCountry(string fifaCode)
        {
            throw new NotImplementedException();
        }

        public List<Player> GetPlayersByFifaCode(string fifaCode)
        {
            throw new NotImplementedException();
        }
    }
}
