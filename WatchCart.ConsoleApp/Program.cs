using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using WatchCart.Models;
using WatchCart.Models.Constants;
using WatchCart.Orders;
using WatchCart.Repository;
using WatchCart.Service;

namespace WatchCart.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *  Prepare the instance of all dependencies and inject into respective objects.
             */

            // It should display a welcome message to the user followed by the options to select 
            // different criterias.

            // Display the details of matched watch with the help of ToString() method
            // Ask the user to confirm about the purchase of watch
            // 1. Yes -> Save the orderdetails into database using OrderRepository
            // 2. No -> Should exit the application
            
            Console.WriteLine("WELCOME TO MY SHOP WATCH KISKO!!!!!!!");
            Console.WriteLine("*********************************************");

            try {
                while (true)
                {
                    Console.WriteLine("Press 1: to Place order,Press 2: to Exit,Press 3: to Restart");
                    var opiton = Convert.ToInt32(Console.ReadLine());

                    //Place order
                    if (opiton == 1)
                    {
                        StartApp();

                    }
                    // exit application 
                    if (opiton == 2)
                    {
                        System.Environment.Exit(0);
                    }
                    // clear screen
                    if (opiton == 3)
                    {
                        Console.Clear();
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                StartApp();
            }
        }//end of Main Method


        private static void PrintWatchTypeMenu()
        {
            var option = 1;
            
            foreach (var item in Enum.GetNames(typeof(WatchTypes)))
            {
                
                Console.WriteLine("{0}:{1}",item,option++);
            }


        }


        private static void BrandTypeMenu()
        {
            var option = 1;

            foreach (var item in Enum.GetNames(typeof(BrandName)))
            {

                Console.WriteLine("{0}:{1}", item, option++);
            }

        }

        private static void StripeTypeMenu()
        {
            var option = 1;

            foreach (var item in Enum.GetNames(typeof(StrapType)))
            {

                Console.WriteLine("{0}:{1}", item, option++);
            }
        }
        private static void StripColorMenu()
        {
            var option = 1;

            foreach (var item in Enum.GetNames(typeof(StrapColor)))
            {

                Console.WriteLine("{0}:{1}", item, option++);
            }
        }

        private static void SegmentColorMenu()
        {
            var option = 1;

            foreach (var item in Enum.GetNames(typeof(Segment)))
            {

                Console.WriteLine("{0}:{1}", item, option++);
            }
        }


        private static void StartApp()
        {
            Console.WriteLine("Wacth Type Options: ");
            PrintWatchTypeMenu();
            Console.WriteLine("BrandName Options: ");
            BrandTypeMenu();
            Console.WriteLine("StrapType Options: ");
            StripeTypeMenu();
            Console.WriteLine("StrapColor Options: ");
            StripColorMenu();
            Console.WriteLine("Segment Options: ");
            SegmentColorMenu();

            var catalog = new WatchCatalog();
            catalog.Catalog=new List<Watch>{
                new AnalogWatch() { WatchId = 1101, BrandName = "FASTTRACK", StrapType = "METALIC", StrapColor = "BLACK", Segment = "BASIC", Price = 4000, NumberOfHands = 2, HasCalender = false },
                 new AnalogWatch() { WatchId = 1102, BrandName = "FASTTRACK", StrapType = "METALIC", StrapColor = "BLACK", Segment = "BASIC", Price = 4000 },
                 new AnalogWatch() { WatchId = 1103, BrandName = "FASTTRACK", StrapType = "METALIC", StrapColor = "BLACK", Segment = "BASIC", Price = 4000 },
                 new AnalogWatch() { WatchId = 1104, BrandName = "FASTTRACK", StrapType = "METALIC", StrapColor = "BLACK", Segment = "BASIC", Price = 4000 },
                 new DigitalWatch() { WatchId = 1105, BrandName = "FASTTRACK", StrapType = "METALIC", StrapColor = "BLACK", Segment = "BASIC", Price = 4000 },
            };
            //var WatchCartApp = new WatchCartApp( new WatchService(new WatchRepository( new WatchCatalog())), new OrderRepository( new WatchStoreDbContext()));
            var WatchCartApp = new WatchCartApp(new WatchService(new WatchRepository(catalog)), new OrderRepository(new WatchStoreDbContext()));
            try
            {
                var Watch = WatchCartApp.GetWatchByUserChoice();
            
            Console.WriteLine("********************************************************");
            Console.WriteLine("Press 1 to Process order else press any key to Exit");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            if (userChoice == 1)
            {
                WatchCartApp.ProcessOrder(Watch);
            }
            else
            {
                System.Environment.Exit(0);
            }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }

        }
    }
}
