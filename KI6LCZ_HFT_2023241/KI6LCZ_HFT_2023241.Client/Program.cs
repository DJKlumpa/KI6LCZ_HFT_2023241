using System;
using KI6LCZ_HFT_2023241.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConsoleTools;


namespace KI6LCZ_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task&Thread
            string loading = "Kedvenc karácsonyi ételem a diós bejgli. \nÉs a mákos is.";
            int maxTimeout = 8000;
            int timeoutCounter = 0;
            Random rnd = new Random();

            Task t = new Task(() =>
            {
                foreach (char item in loading)
                {
                    if (timeoutCounter >= maxTimeout)
                    {
                        break;
                    }

                    Console.Write(item);
                    int timeout = rnd.Next(0, maxTimeout - timeoutCounter);
                    timeoutCounter += timeout;
                    Thread.Sleep(200);
                }
            }, TaskCreationOptions.LongRunning);
            #endregion
            
            #region GetOneMenu
            var getOneMenu = new ConsoleMenu(args, level: 1)
            
            #endregion
        }
    }
}
