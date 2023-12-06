using System;
using KI6LCZ_HFT_2023241.Models;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ConsoleTools;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;


namespace KI6LCZ_HFT_2023241.Client
{
    class Program
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
            RestService restService = new RestService("http://localhost:41147");
            #region GetAllMenu
            var getAllMenu = new ConsoleMenu(args, level: 1)
            .Add("Get all musics", () => GetAllInstance(restService, "music"))
           .Add("Get all albums", () => GetAllInstance(restService, "album"))
           .Add("Get all bands", () => GetAllInstance(restService, "band"))
           .Add("Back", ConsoleMenu.Close)
           .Configure(config =>
           {
               config.Selector = "~>";
               config.EnableFilter = true;
               config.Title = "Get all data\n";
               config.EnableBreadcrumb = true;
               config.WriteBreadcrumbAction = titles => Console.Write(string.Join(" > ", titles));
           });
            #endregion


            static void GetAllInstance(RestService rs, string model)
            {

                Console.Clear();
                Console.WriteLine("GET ALL");

                if (model == "hospital")
                {
                    rs.Get<Music>($"{model}").ForEach(x => Console.WriteLine(x.AllData));
                }
                else if (model == "doctor")
                {
                    rs.Get<Album>($"{model}").ForEach(x => Console.WriteLine(x.AllData));
                }
                else
                {
                    rs.Get<Band>($"{model}").ForEach(x => Console.WriteLine(x.AllData));
                }


                Console.WriteLine("\nPRESS ENTER TO CONTINUE");
                Console.ReadLine();
            }
        }
    }
}
