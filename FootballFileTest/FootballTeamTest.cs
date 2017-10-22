using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FootballTeam.models;
using FootballTeam.Helpers;
using System.Reflection;
using System.IO;
using System.Data;

namespace FootballFileTest
{
    [TestClass]
    public class FootballTeamTest
    {
        /// <summary>
        /// This method tests the repository method  GetTeamNameWithScore to check if absolute score and name is returned in fteam object
        /// </summary>
        [TestMethod]
        public void TestGetTeamNameWithScoreMethod()
        {
            List<FTeam> footballTeamData = new List<FTeam>()
            {
                new FTeam { Team ="1.Arsenal", P=38, W =26, L=9, D =3, F=60, A=30, Pts= 87 },
                new FTeam { Team ="2.Liverpool", P=38, W =24, L=8, D =6, F=40, A=20, Pts= 80 },
                new FTeam { Team ="3.Newcastle", P=38, W =24, L=8, D =6, F=50, A=25, Pts= 80 }
            };

             FTeam objfootballTeamData = FteamRepository.GetTeamNameWithScore(footballTeamData);

            //smallest diff between F and A feild is 25
             
            Assert.AreEqual(20, objfootballTeamData.ScoreDiff);
            Assert.AreEqual("2.Liverpool", objfootballTeamData.Team);
            Assert.AreEqual("Liverpool", objfootballTeamData.Team.Split('.')[1]);
        }
        [TestMethod]
        public void TestValidateMethod()
        {
            List<string> columnsNames = new List<string>() { "Team", "P", "W", "L", "D", "F", "A", "Pts" };
            //Get embedded resource file
            var resourceName = "FootballTeam.Files.football.csv";
            var assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(resourceName);

            // Read embeddded resource file into datatable.
            DataTable FteamdataTable = ReadCsvFile.GetDataTabletFromCSVFile(stream);
           
            //Check headers and header count
            // dummy csv file have column which points to XYZPts instead of Pts hence validatecheck will fail
            bool validationCheck = ValidateFile.ValidateDataFromFile(FteamdataTable);

            Assert.AreEqual(false, validationCheck);
           
        }
    }
}
