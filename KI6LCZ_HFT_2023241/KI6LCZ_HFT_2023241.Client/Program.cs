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
            #region Task&Thread     change this!!!!!!!
            string loading = "This is the half ";
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
            #region GetOneMenu
            var getOneMenu = new ConsoleMenu(args, level: 1)
        .Add("Get one hospital", () => GetOneInstance(restService, "hospital"))
        .Add("Get one doctor", () => GetOneInstance(restService, "doctor"))
        .Add("Get one patient", () => GetOneInstance(restService, "patient"))
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

            #region GetAllInstance
            static void GetAllInstance(RestService restService, string model)
            {

                Console.Clear();
                Console.WriteLine("GET ALL");

                if (model == "music")
                {
                    restService.Get<Music>($"{model}").ForEach(x => Console.WriteLine(x.AllData));
                }
                else if (model == "album")
                {
                    restService.Get<Album>($"{model}").ForEach(x => Console.WriteLine(x.AllData));
                }
                else
                {
                    restService.Get<Band>($"{model}").ForEach(x => Console.WriteLine(x.AllData));
                }

                
            }
            
            Console.WriteLine("\nPRESS ENTER TO CONTINUE");
            Console.ReadLine();
            #endregion
            #region GetOneInstance
            static void GetOneInstance(RestService restService, string model)
            {
                Console.Clear();
                Console.WriteLine("GET ONE");

                if (model == "music")
                {
                    restService.Get<Music>($"{model}").ForEach(x => Console.WriteLine($"[{x.Id}] - {x.Title}"));

                    Console.Write("Select an id: "); Console.WriteLine();
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();

                    var music = restService.GetSingle<Music>($"{model}/{id}");
                    Console.WriteLine($"{music.AllData} - Albums");

                }
                else if (model == "album")
                {
                    restService.Get<Album>($"{model}").ForEach(x => Console.WriteLine($"[{x.Id}] - {x.AlbumName}"));

                    Console.Write("Select an id: "); Console.WriteLine();
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();

                    var album = restService.GetSingle<Band>($"{model}/{id}");
                    Console.WriteLine($"{album.AllData} - Bands: {album.AlbumCounter}");
                }
                else
                {
                    restService.Get<Band>($"{model}").ForEach(x => Console.WriteLine($"[{x.Id}] - {x.BandName}"));

                    Console.Write("Select an id: "); Console.WriteLine();
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();

                    var band = restService.GetSingle<Band>($"{model}/{id}");
                    Console.WriteLine($"{band.AllData}");
                }
            Console.WriteLine("\nPRESS ENTER TO CONTINUE");
            Console.ReadLine();
            #endregion
            }
        }
    }
}
