using System;

namespace FootballTeam.Helpers
{
    public static class ConsoleLogger
    {
        /// <summary>
        /// Logs error from all classes
        /// </summary>
        /// <param name="message">Error message recieved from classes</param>
        public static void Log(string message)
        {
            Console.WriteLine(message);
            //Console.ReadLine();
        }
    }
}
