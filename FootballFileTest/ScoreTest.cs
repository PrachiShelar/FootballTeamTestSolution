using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FootballTeam.models;

namespace FootballFileTest
{
    [TestClass]
    public class ScoreTest
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

             FTeam objfootballTeamData = FTeamRepository.GetTeamNameWithScore(footballTeamData);

            //smallest diff between F and A feild is 25
             
            Assert.AreEqual(20, objfootballTeamData.ScoreDiff);
            Assert.AreEqual("Liverpool", objfootballTeamData.Team.Split('.')[1]);
        }
    }
}
