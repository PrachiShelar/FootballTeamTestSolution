using System;
using System.Collections.Generic;
using System.Data;

namespace FootballTeam.Helpers
{
    public class ValidateFile
    {
        /// <summary>
        /// This method is to validate Csv Data column
        /// </summary>
        /// <param name="csvData"></param>
        /// <returns>Return success or fail validation check</returns>
        public static bool ValidateDataFromFile(DataTable csvData)
        {
            //Check colum count and Column names of file are valid
            var headerCount = csvData.Columns.Count;
            if (headerCount == 9)
            {
                List<string> columnsNames = new List<string>() { "Team", "P", "W", "L", "D", "F", "A", "Pts" };
                DataColumnCollection columns = csvData.Columns;
               
                bool iscolumnExist = true;
                try
                {
                    if (columns != null)
                    {
                        foreach (string columnName in columnsNames)
                        {
                            if (!columns.Contains(columnName))
                            {
                                iscolumnExist = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        iscolumnExist = false;
                    }
                }
                catch (Exception ex)
                {
                    ConsoleLogger.Log("Column name is not valid" + ex.InnerException);
                }
                return iscolumnExist;
            }
            else
            {
                return false;
            }
        }
    }
}
