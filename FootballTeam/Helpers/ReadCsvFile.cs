using System;
using System.Data;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace FootballTeam.Helpers
{
    public static class ReadCsvFile
    {
        /// <summary>
        /// This method parse input CSV file into DataTable.
        /// </summary>
        /// <param name="stream">Input to function is emabedded stream</param>
        /// <returns></returns>
        public static DataTable GetDataTabletFromCSVFile(Stream stream)
        {
            DataTable csvData = new DataTable();
            
            try
            {
                if (stream == null)
                {
                    return null;
                }
                using (TextFieldParser csvReader = new TextFieldParser(stream))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        csvData.Columns.Add(datecolumn);
                    }
                  
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.Log("File not found");
            }
            return csvData;
        }
    }
}
