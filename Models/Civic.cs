using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipSystem.Models
{
    // Civic inherites from car, all the fields that car has we will implement here along
    // with fields that are unique to it specifically 
    public class Civic : Car
    {
        private int ModelId { get; set; }

        // Constructor for creating the object 
        public Civic(double price, string brand, string name) : base(price, brand, name)
        {
            // Creating a model id to reference based off of the list
            ModelId = ModelId = Program.CivicList.Count() + 1;
        }

        // printing the Civic list
        public static void Print(List<Civic> CivicList)
        {
            Console.WriteLine("Civic's:");
            for (int i = 0; i < CivicList.Count; i++)
            {
                Console.WriteLine($"\t Name: {CivicList[i].Name}, Id: {CivicList[i].ModelId}");
            }
        }
    }
}
