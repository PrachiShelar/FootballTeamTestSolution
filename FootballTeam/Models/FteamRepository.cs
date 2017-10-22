using FootballTeam.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FootballTeam.models
{
    public static class FteamRepository
    {
        /// <summary>
        /// This method fetch team with absolute score difference
        /// </summary>
        /// <param name="footballData"></param>
        /// <returns> Return Fteam</returns>
        public static FTeam GetTeamNameWithScore(List<FTeam> footballData)
        {
            try
            {
                footballData.ForEach(col => col.ScoreDiff = Math.Abs(col.F - col.A));
                int minvalue = footballData.Min(x => x.ScoreDiff.Value);
                FTeam FData = footballData.Where(x => x.ScoreDiff == minvalue).FirstOrDefault();

                return FData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}