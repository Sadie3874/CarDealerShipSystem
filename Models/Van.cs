using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipSystem.Models
{
    public class Van: Car
    {
        // Van inherates from Car but needs some unique fields 
        private int ModelId { get; set; }

        // Van constructor 
        public Van(double price, string brand, string name) : base(price, brand, name)
        {
            // Creating a model id to reference based off of the list
            ModelId = Program.VanList.Count() + 1;
        }

        // Printing the van list 
        public static void Print(List<Van> VanList)
        {
            Console.WriteLine("Vans:");
            for (int i = 0; i < VanList.Count; i++)
            {
                Console.WriteLine($" \t Name: {VanList[i].Name}, Id: {VanList[i].ModelId}");
            }
        }

    }
}
