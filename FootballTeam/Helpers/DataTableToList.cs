using FootballTeam.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace FootballTeam.Helpers
{
    /// <summary>
    /// Static helper class for utility functions
    /// </summary>
    public static class DataTableToList
    {
        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static List<T> GetDataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();
                    // Remove team row which have '-' in team
                    if (string.IsNullOrWhiteSpace(row["Team"].ToString().Replace('-', ' ')))
                    {
                        continue;
                    }
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }
                return list;
            }
            catch(Exception ex)
            {
                ConsoleLogger.Log("Input file have invalid data." + ex.InnerException);
            }
            return null;
        }
    }
}