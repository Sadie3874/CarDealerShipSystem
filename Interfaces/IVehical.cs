using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipSystem.Interfaces
{
    public interface IVehical
    {
        // Function for printing all the bought cars 
        static abstract void BoughtCarPrint(Dictionary<string, double> BoughtCarList);
    }
}
