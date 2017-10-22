using FootballTeam.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

namespace FootballTeam.Helpers
{
    public class CSVData : IData
    {
        /// <summary>
        /// Get list of Fteam with validation check
        /// </summary>
        /// <returns> Return list of Fteam</returns>
        public List<FTeam> GetData()
        {
            try
            {
                //Get embedded resource file
                var resourceName = "FootballTeam.Files.football.csv";
                var assembly = Assembly.GetExecutingAssembly();
                Stream stream = assembly.GetManifestResourceStream(resourceName);

                // Read embeddded resource file into datatable.
                DataTable data = ReadCsvFile.GetDataTabletFromCSVFile(stream);
                
                //Validate csv file
                if(data != null)
                {
                    bool validationCheck = ValidateFile.ValidateDataFromFile(data);

                    if (validationCheck)
                        return DataTableToList.GetDataTableToList<FTeam>(data);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.Log("Validate File as per requirements" + ex.InnerException);
            }
             
            return null;
        }
    }
}
