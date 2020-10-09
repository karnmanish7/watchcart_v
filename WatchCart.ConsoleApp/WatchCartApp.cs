using AutoMapper;
using System;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using WatchCart.Models;
using WatchCart.Models.Constants;
using WatchCart.Orders;
using WatchCart.Service;

namespace WatchCart.ConsoleApp
{
    public class WatchCartApp
    {
        private IWatchService _watchService;
        private IOrderRepository _repository;

        public WatchCartApp(IWatchService watchService, IOrderRepository repository){
            this._watchService = watchService;
            this._repository = repository;
        }
        /// <summary>
        /// This method is used to accept the user choice of WatchType, BrandName, StrapType, StrapColor and Segment
        /// by displaying a menu step by step. Every Menu should also have an option to exit at any time.
        /// </summary>
        /// <returns>Returns a Watch Basis upon the options selected</returns>
        public Watch GetWatchByUserChoice()
        {
            //implement the code to display the menu options
            //after getting all inputs, retreive the watch based upon the choice

            Console.WriteLine("****************************************************");
            Console.WriteLine("Please Provide the desired value from above Information to find the matched combination from the below combination ");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("Watch Type: ");
            int watchType = Convert.ToInt32(Console.ReadLine());
            if (InputValidatorService.Validate(watchType.ToString(), 2) == 0)
                throw new InvalidInputException("Watch Type");

            Console.WriteLine("BrandName Type: ");
            int brandName = Convert.ToInt32(Console.ReadLine());
            if (InputValidatorService.Validate(brandName.ToString(), 3) == 0)
                throw new InvalidInputException("BrandName Type");
            
            Console.WriteLine("StrapType Type: ");
            
            int straptype = Convert.ToInt32(Console.ReadLine());
            if (InputValidatorService.Validate(straptype.ToString(), 3) == 0)
                throw new InvalidInputException("StrapType Type");

            Console.WriteLine("StrapColor Type: ");
            int strapcolor = Convert.ToInt32(Console.ReadLine());
            if (InputValidatorService.Validate(strapcolor.ToString(), 3) == 0)
                throw new InvalidInputException("StrapColor Type");

            Console.WriteLine("Segment Type: ");
            int segment = Convert.ToInt32(Console.ReadLine());
            if (InputValidatorService.Validate(segment.ToString(), 3) == 0)
                throw new InvalidInputException("Segment Type");


            Watch foundWatch =   PrintMatchedWatch(watchType, brandName, straptype, strapcolor, segment);
           

            return foundWatch;
        }

        /// <summary>
        /// Helper method to transform Watch object into OrderDetails
        /// </summary>
        /// <param name="watch">Watch Object</param>
        /// <returns>OrderDetails</returns>
        private static OrderDetails MapToOrderDetails(Watch watch)
        {
            var orderDeatils = new OrderDetails();
            if (watch.Type.ToString()== "AnalogWatch")
            {
                orderDeatils.OrderDetail = ((AnalogWatch)watch).ToString();
            }
            else
            {
                orderDeatils.OrderDetail = ((DigitalWatch)watch).ToString();
            }
            orderDeatils.CreateDate = DateTime.UtcNow;
            return orderDeatils;
        }

        /// <summary>
        /// This method is used to save the order in Database with the help of orderRepository
        /// </summary>
        /// <param name="watch">Watch Object</param>
        /// <param name="placeOrder">user choice, Want to place order(1,2)?</param>
        public void ProcessOrder(Watch watch)
        {
           
          this._repository.save(MapToOrderDetails(watch));
            Console.WriteLine("Order Saved Successfully");
            Console.WriteLine("*----------------------------------------------------------------*");
           
        }

      

        private Watch PrintMatchedWatch(int watchType, int brandName, int straptype, int strapcolor, int segment)
        {
           Watch foundWatch =  this._watchService.GetWatches(watchType, brandName, straptype, strapcolor, segment);

            Console.WriteLine(foundWatch.ToString());

            return foundWatch;
        }
    }
}
