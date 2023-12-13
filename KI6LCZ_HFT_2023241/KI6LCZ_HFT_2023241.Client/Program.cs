﻿using System;
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
        static RestService restService;
        static void Main(string[] args)
        {
            #region Task&Thread     change this!!!!!!!
            string loading = "This is the Haladó Fejlesztés Technikák half-semester task.";
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

            restService = new RestService("http://localhost:54376");

            var subMenuMusic = new ConsoleMenu(args, level: 1)
            .Add("Create", () => Create(restService, "music"))
            .Add("Update", () => Update(restService, "music"))
            .Add("Delete", () => Delete(restService, "music"))
            .Add("Get One Data", () => GetOneInstance(restService, "music"))
            .Add("Gett All Data", () => GetAllInstance(restService, "music"))
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.EnableFilter = true;
                config.Title = "Submenu";
                config.EnableBreadcrumb = true;
                config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
            });
            var subMenuAlbum = new ConsoleMenu(args, level: 1)
            .Add("Create", () => Create(restService, "album"))
            .Add("Update", () => Update(restService, "album"))
            .Add("Delete", () => Delete(restService, "album"))
            .Add("Get One Data", () => GetOneInstance(restService, "album"))
            .Add("Gett All Data", () => GetAllInstance(restService, "album"))
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.EnableFilter = true;
                config.Title = "Submenu";
                config.EnableBreadcrumb = true;
                config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
            });

            var subMenuBand = new ConsoleMenu(args, level: 1)
            .Add("Create", () => Create(restService, "band"))
            .Add("Update", () => Update(restService, "band"))
            .Add("Delete", () => Delete(restService, "band"))
            .Add("Get One Data", () => GetOneInstance(restService, "band"))
            .Add("Gett All Data", () => GetAllInstance(restService, "band"))
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.EnableFilter = true;
                config.Title = "Submenu";
                config.EnableBreadcrumb = true;
                config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
            });

            var subMenuStats = new ConsoleMenu(args, level: 1)
                    .Add("Create", () => Create(restService, "album"))
                    .Add("Create", () => Create(restService, "album"))
                    .Add("Create", () => Create(restService, "album"))
                    .Add("Create", () => Create(restService, "album"))
                    .Add("Create", () => Create(restService, "album"))
                        .Configure(config =>
{
                        config.Selector = "--> ";
                        config.EnableFilter = true;
                        config.Title = "Submenu";
                        config.EnableBreadcrumb = true;
                        config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
});



            var menu = new ConsoleMenu(args, level: 0)
              .Add("Music", subMenuMusic.Show)
              .Add("Album", subMenuAlbum.Show)
              .Add("Band", subMenuBand.Show)
              .Add("Exit", () => Environment.Exit(0))
              .Configure(config =>
              {
                  config.Selector = "--> ";
                  config.EnableFilter = true;
                  config.Title = "Main menu";
                  config.EnableWriteTitle = true;
                  config.EnableBreadcrumb = true;
              });

            menu.Show();

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
                Console.WriteLine("\nPRESS ENTER TO CONTINUE");
                Console.ReadLine();
            }

            
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
            static void Update(RestService rs, string model)
            {
                Console.Clear();
                Console.WriteLine("UPDATE");
                if (model == "music")
                {
                    rs.Get<Music>($"{model}").ForEach(x => Console.WriteLine($"[{x.Id}] - {x.Title}"));

                    Console.Write("Select an id: "); Console.WriteLine();
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();


                    Console.WriteLine("Must fill in the following options:");
                    Console.Write("music Title: ");
                    string title = Console.ReadLine(); Console.WriteLine();

                    Console.Write("music Length: ");
                    double length = double.Parse(Console.ReadLine()); Console.WriteLine();
                    Console.Clear();

                    Console.Write("music Genre: ");
                    string genre = Console.ReadLine(); Console.WriteLine();
                    Console.Clear();


                    rs.Put<Music>(new Music() { Id = id, Title = title, Length = length, Genre = genre }, model);
                }
                else if (model == "album")
                {
                    rs.Get<Album>($"{model}").ForEach(x => Console.WriteLine($"[{x.Id}] - {x.AlbumName}"));

                    Console.Write("Select an id: "); Console.WriteLine();
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();


                    Console.WriteLine("Must fill in the following options:");
                    Console.Write("album Name: ");
                    string name = Console.ReadLine(); Console.WriteLine();

                    Console.Write("album Year: ");
                    int year = int.Parse(Console.ReadLine()); Console.WriteLine();
                    Console.Clear();

                    Console.Write("album Genre: ");
                    string genre = Console.ReadLine(); Console.WriteLine();
                    Console.Clear();



                    rs.Put<Album>(new Album() { Id = id, AlbumName = name, Year = year, Genre = genre }, model);
                }
                else
                {
                    rs.Get<Band>($"{model}").ForEach(x => Console.WriteLine($"[{x.Id}] - {x.BandName}"));

                    Console.Write("Select an id: "); Console.WriteLine();
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();


                    Console.WriteLine("Must fill in the following options:");
                    Console.Write("band Name: ");
                    string name = Console.ReadLine(); Console.WriteLine();

                    Console.Write("band Year of formation: ");
                    int year = int.Parse(Console.ReadLine()); Console.WriteLine();

                    Console.Write("band Address: ");
                    string address = Console.ReadLine(); Console.WriteLine();

                    rs.Put<Band>(new Band() { Id = id, BandName = name, Year = year }, model);
                }


                Console.Clear();
                Console.WriteLine("Item updated!");
                Console.WriteLine("\nPRESS ENTER TO CONTINUE");
                Console.ReadLine();
            }
            static void Create(RestService rs, string model)
            {
                Console.Clear();
                Console.WriteLine("CREATE");

                if (model == "music")
                {
                    Console.WriteLine("Must fill in the following options:");
                    Console.Write("Select an id: "); Console.WriteLine();
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();


                    Console.WriteLine("Must fill in the following options:");
                    Console.Write("music Title: ");
                    string title = Console.ReadLine(); Console.WriteLine();

                    Console.Write("music Length: ");
                    double length = double.Parse(Console.ReadLine()); Console.WriteLine();
                    Console.Clear();

                    Console.Write("music Genre: ");
                    string genre = Console.ReadLine(); Console.WriteLine();
                    Console.Clear();

                    rs.Post<Music>(new Music() { Id = id, Title = title, Length = length, Genre = genre }, model);
                }
                else if (model == "album")
                {
                    rs.Get<Album>($"{model}").ForEach(x => Console.WriteLine($"[{x.Id}] - {x.AlbumName}"));

                    Console.Write("Select an id: "); Console.WriteLine();
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();


                    Console.WriteLine("Must fill in the following options:");
                    Console.Write("album Name: ");
                    string name = Console.ReadLine(); Console.WriteLine();

                    Console.Write("album Year: ");
                    int year = int.Parse(Console.ReadLine()); Console.WriteLine();
                    Console.Clear();

                    Console.Write("album Genre: ");
                    string genre = Console.ReadLine(); Console.WriteLine();
                    Console.Clear();



                    rs.Post<Album>(new Album() { Id = id, AlbumName = name, Year = year, Genre = genre }, model);
                }
                else
                {
                    rs.Get<Band>($"{model}").ForEach(x => Console.WriteLine($"[{x.Id}] - {x.BandName}"));

                    Console.Write("Select an id: "); Console.WriteLine();
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();


                    Console.WriteLine("Must fill in the following options:");
                    Console.Write("band Name: ");
                    string name = Console.ReadLine(); Console.WriteLine();

                    Console.Write("band Year of formation: ");
                    int year = int.Parse(Console.ReadLine()); Console.WriteLine();

                    Console.Write("band Address: ");
                    string address = Console.ReadLine(); Console.WriteLine();

                    rs.Put<Band>(new Band() { Id = id, BandName = name, Year = year }, model);



                    rs.Post<Band>(new Band() { Id = id, BandName = name, Year = year }, model);
                }

                Console.Clear();
                Console.WriteLine("Item created!");
                Console.WriteLine("\nPRESS ENTER TO CONTINUE");
                Console.ReadLine();
            }

            static void Delete(RestService rs, string model)
            {
                Console.Clear();
                Console.WriteLine("DELETE");
                if (model == "music")
                {
                    rs.Get<Music>($"{model}").ForEach(x => Console.WriteLine($"[{x.Id}] - {x.Title}"));

                    Console.Write("Select an id: "); Console.WriteLine();
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();

                    rs.Delete(id, model);

                }
                else if (model == "album")
                {
                    rs.Get<Album>($"{model}").ForEach(x => Console.WriteLine($"[{x.Id}] - {x.AlbumName}"));

                    Console.Write("Select an id: "); Console.WriteLine();
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();

                    rs.Delete(id, model);
                }
                else
                {
                    rs.Get<Band>($"{model}").ForEach(x => Console.WriteLine($"[{x.Id}] - {x.BandName}"));

                    Console.Write("Select an id: "); Console.WriteLine();
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();

                    rs.Delete(id, model);
                }
                Console.Clear();
                Console.WriteLine("Item deleted!");
                Console.WriteLine("\nPRESS ENTER TO CONTINUE");
                Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("Item updated!");
            Console.WriteLine("\nPRESS ENTER TO CONTINUE");
            Console.ReadLine();
        }


    }
}
