using System;
using System.Linq;
using FootballTeam.Helpers;
using System.Collections.Generic;
using FootballTeam.models;

namespace FootballTeam
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IData dataobj = new CSVData();
                DataHub hubobj = new DataHub(dataobj);
                List<FTeam> footballteamData = hubobj.GetData();

                if (footballteamData != null && footballteamData.Any())
                {
                    //FTeam teamDetails;
                    FTeam teamDetails = FTeamRepository.GetTeamNameWithScore(footballteamData);

                    //Printing Team name without name and number.
                    string teamName = teamDetails.Team.Split('.')[1];
                    Console.WriteLine("Team Name :" + teamName);
                    Console.WriteLine("The smallest difference in ‘for’ and ‘against’ goals:" + teamDetails.ScoreDiff);
                    Console.ReadLine();
                }
                else
                {
                    ConsoleLogger.Log("No Data Recieved");
                }
            }
            catch(Exception ex)
            {
                ConsoleLogger.Log(ex.Message);
            }
            Console.ReadLine();
        }

    }
}