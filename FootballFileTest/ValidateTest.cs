using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FootballTeam.Helpers;
using System.Reflection;
using System.IO;
using System.Data;

namespace FootballFileTest
{
    [TestClass]
    public class ValidateTest
    {
        [TestMethod]
        public void TestValidateSuccessMethod()
        {
            List<string> columnsNames = new List<string>() { "Team", "P", "W", "L", "D", "F", "A", "Pts" };
            //Get embedded resource file
            var resourceName = "FootballFileTest.Files.dummyFootballSuccess.csv";
            var assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(resourceName);

            // Read embeddded resource file into datatable.
            DataTable FteamdataTable = ReadCsvFile.GetDataTabletFromCSVFile(stream);
           
            //Check headers and header count
            bool validationCheck = ValidateFile.ValidateDataFromFile(FteamdataTable);

            Assert.AreEqual(true, validationCheck);
        }

        [TestMethod]
        public void TestValidateFailMethod()
        {
            List<string> columnsNames = new List<string>() { "Team", "P", "W", "L", "D", "F", "A", "Pts" };
            //Get embedded resource file
            var resourceName = "FootballFileTest.Files.dummyFootballFailure.csv";
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
