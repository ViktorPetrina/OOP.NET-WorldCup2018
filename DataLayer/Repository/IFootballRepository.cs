﻿using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IFootballRepository
    {
        List<Match> GetAllMatches();
        List<Match> GetMatchesByCountry(string fifaCode);
        List<Player> GetPlayersByFifaCode(string fifaCode);
        List<Team> GetAllTeams();
        List<Team> GetAllResults();
        List<GroupResult> GetAllGroupResults();
    }
}
