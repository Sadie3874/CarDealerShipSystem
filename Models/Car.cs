using CarDealerShipSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipSystem.Models
{
    // Inherates from from a interface IVehical 
    public abstract class Car : IVehical
    {
        // All the fields all children of Cars must have 
        public double Price { get; set; }
        public string Brand { get; set; }
        public string Name { get; set;}

        // Creating an id for each car, a id cannot be 0 so we must start at 1
        private int Id { get; set; }
        private int CurrentId = 1;

        public Car(double price, string brand, string name) 
        {
            // setting the price. brand and id 
            Price = price;
            Brand = brand;
            Name = name;
            Id = CurrentId;
            // increasing the id for the next created car
            CurrentId++;
        }

        // function that is inheritend from the interface IVechical, this prints a bought car list 
        public static void BoughtCarPrint(Dictionary<string, double> BoughtCarList)
        {
            // printing a dictonary thats key is the name and value is the price 
            Console.WriteLine("Bought Car List: ");
            foreach(KeyValuePair<string, double> boughtCar in BoughtCarList)
            {
                Console.WriteLine($"\tName: {boughtCar.Key}, Price: {boughtCar.Value}");
            }
        }

        // These functions are for verifying that a car exisits in the list. 
        public static bool SearchTruck(List<Truck> TruckList, int SearchId)
        {
            // Beacause we start our search id at one and lists start at 0
            // we need to find the correct id
            for (int i = 0; i <= TruckList.Count - 1; i++)
            {
                // if the searchid is more 1 then we subtract 1 from it so it is one less
                if(SearchId > 1)
                {
                    if (TruckList[i].Id == (SearchId - 1))
                    {
                        // return true that that it is valid 
                        return true;
                    }
                }
                else
                {
                    // else this value would be 1 so we dont need to subtract a value
                    if (TruckList[i].Id == SearchId)
                    {
                        return true;
                    }
                }
                
            }
            // if it is not we are returning false 
            return false;
        }

        // We do the same verifying to the other types of Car lists 
        public static bool SearchCivic(List<Civic> CivicList, int SearchId)
        {
            for (int i = 0; i <= CivicList.Count - 1; i++)
            {
                if (SearchId > 1)
                {
                    if (CivicList[i].Id == (SearchId - 1))
                    {
                        return true;
                    }
                }
                else
                {
                    if (CivicList[i].Id == SearchId)
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public static bool SearchVan(List<Van> VanList, int SearchId)
        {
            for (int i = 0; i <= VanList.Count - 1; i++)
            {
                if (SearchId > 1)
                {
                    if (VanList[i].Id == (SearchId - 1))
                    {
                        return true;
                    }
                }
                else
                {
                    if (VanList[i].Id == SearchId)
                    {
                        return true;
                    }
                }

            }
            return false;
        }

    }
}
