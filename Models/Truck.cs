using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipSystem.Models
{
    public class Truck : Car
    {
        // Truck inherates from Car but needs some unique fields 
        private int ModelId { get; set; }
        public string Type { get; set; }

        // Truck constructor 
        public Truck(double price, string type, string brand, string name) : base(price, brand ,name)
        {
            Type = type;
            // Creating a model id to reference based off of the list
            ModelId = Program.TruckList.Count() + 1;
        }

        // Printing the truck list 
        public static void Print(List<Truck> TruckList)
        {
            Console.WriteLine("Trucks:");

            for (int i = 0; i < TruckList.Count; i++)
            {
                Console.WriteLine($"\t Name: {TruckList[i].Name}, Id: {TruckList[i].ModelId}");
            }
        }
    }
}
