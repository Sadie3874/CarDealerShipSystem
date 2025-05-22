using CarDealerShipSystem.Models;
using System;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
namespace CarDealerShipSystem
{
    internal class Program
    {
        // creating list of all the cars
        public static List<Truck> TruckList = new List<Truck>();
        public static List<Civic> CivicList = new List<Civic>();
        public static List<Van> VanList = new List<Van>();
        public static Dictionary<string, double> boughtCarList = new Dictionary<string, double>(); 

        static void Main(string[] args)
        {
            // Adding default data to the lists.
            TruckList.Add(new Truck(2000.00, "Pickup", "RAM", "RAM 1500")); 
            TruckList.Add(new Truck(307.30, "Pickup", "FORD", "FORD F150"));

            VanList.Add(new Van(14000.21, "Honda", "Honda Odyssey"));
            VanList.Add(new Van(8000.00, "Toyota", "Toyota Sienna"));

            CivicList.Add(new Civic(3580.54, "Honda", "Sedan"));
            CivicList.Add(new Civic(7654.90, "Toyota", "Sedan Hybrid"));

            // Default starting money for user to spend on cars. 
            double money = 15000;

            Console.WriteLine("Welcome to the Car Dealership System. What can we do for you?");

            // while loop for the main page 
            bool isRunning = true;
            while (isRunning)  
            {
                Console.WriteLine("Options: ");
                Console.WriteLine("1. Create new Car "); 
                Console.WriteLine("2. Buy Car"); 
                Console.WriteLine("3. Sell Car"); 
                Console.WriteLine("4. Details of Car");
                Console.WriteLine("5. Exit");

                string input = Console.ReadLine();
                
                // using a switch statement to get userInput of what they would like to do. 
                switch (input)
                {
                    case "1":
                        Console.WriteLine(CreateCar()); // printing the result of creating car 
                        break;
                    case "2":
                        Buy(money); // calling the buy function
                        break;
                    case "3":
                        Sell(money); // calling the sell function 
                        break;
                    case "4":
                        DetailsOfCar(); // calling the DetailsOfCar function
                        break;
                    case "5":
                        isRunning = false; // breaking out of the switch case when user wants to exit
                        return;
                    default:
                        Console.WriteLine("Invaild input. Please try again :)"); // if wrong input, the while loop will loop back again till valid input
                        break;
                }
            }
        }

        public static string CreateCar()
        {
            // getting user input of what kind of car they want to create
            Console.WriteLine("What kind of car would you like to create?");
            Console.WriteLine("1. Truck \n2. Civic \n3. Van");
            // retriving their input
            string input = Console.ReadLine();

            if(input == "1")
            {
                // if the user picks to create a truck, we need the name, price, type and brand of the truck
                try
                {
                    Console.WriteLine("Please enter the name of the car");
                    string nameInput = Console.ReadLine();

                    Console.WriteLine("Enter the price:");
                    string priceInput = Console.ReadLine();
                    double convertedPriceInput = (double)Convert.ToDouble(priceInput);


                    Console.WriteLine("Please enter the type");
                    string typeInput = Console.ReadLine();

                    Console.WriteLine("Please enter the brand");
                    string brandInput = Console.ReadLine();

                    // creating the truck with all the inputs and add it to a list 
                    Truck createTruck = new Truck(convertedPriceInput, typeInput, brandInput, nameInput);
                    TruckList.Add(createTruck);

                    return $"Truck Created: Price: {priceInput}, Type: {typeInput}, Brand: {brandInput}";

                }
                catch(Exception e)
                {
                    return "Invalid input please try again";
                }


            }
            else if (input == "2")
            {
                try
                {
                    // if user creates a civic, the we need the name, price and brand of the car 
                    Console.WriteLine("Please enter the name of the car");
                    string nameInput = Console.ReadLine();

                    Console.WriteLine("Enter the price:");
                    string priceInput = Console.ReadLine();
                    double convertedPriceInput = (double)Convert.ToDouble(priceInput);

                    Console.WriteLine("Please enter the brand");
                    string brandInput = Console.ReadLine();

                    // creating the civic object and adding it to the civic list
                    Civic createCivic = new Civic(convertedPriceInput, brandInput, nameInput);
                    CivicList.Add(createCivic);

                    return $"Civic Created: Price: {priceInput}, Brand: {brandInput}";
                }
                catch (Exception e)
                {
                    return "Invalid input please try again";
                }
                
            }
            else if (input == "3")
            {
                // if user creates a Van, the we need the name, price and brand of the car 
                try
                {
                    Console.WriteLine("Please enter the name of the car");
                    string nameInput = Console.ReadLine();

                    Console.WriteLine("Enter the price:");
                    string priceInput = Console.ReadLine();
                    double convertedPriceInput = (double)Convert.ToDouble(priceInput);

                    Console.WriteLine("Please enter the brand");
                    string brandInput = Console.ReadLine();

                    // creating the Van object and adding it to the van list
                    Van createVan = new Van(convertedPriceInput, brandInput, nameInput);
                    VanList.Add(createVan);

                    return $"Van Created: Price: {priceInput}, Brand: {brandInput}";
                }
                catch (Exception e)
                {
                    return "Invalid input please try again";
                }
                
            }
            else
            {
                // If user inputs something wrong 
                return "Invild please try again"; 
            }
            
        }

        public static void Buy(double money)
        {
            // this is purchising a car, we need the users money and what car they want to buy
            Console.WriteLine("What type car would you like to buy?");
            Console.WriteLine("1. Truck \n2. Civic \n3. Van");
            string input = Console.ReadLine();

            
            if (input == "1")
            {
                // Printing all the trucks 
                Truck.Print(TruckList);
                Console.WriteLine("Which Truck would you like to buy? please enter the id");

                // getting user input and converting it into a int 
                string truckInput = Console.ReadLine();
                int convertedTruckInput = (int)Convert.ToInt32(truckInput);

                // Searching if that id exists, by passing through the list and the users input
                if (Car.SearchTruck(TruckList, convertedTruckInput))
                {
                    // because lists count starts at 0 and our id start at 1 we need to subtract 1 to get the correct object in the list 
                    if(convertedTruckInput > 1)
                    {
                        convertedTruckInput -= 1;
                    }
                    // retriving the correct item in the list 
                    Truck truckItem = TruckList[convertedTruckInput];
                    
                    // If user must have enough money for this car 
                    if(money >= truckItem.Price)
                    {
                        // subtracting the amount of the car from the money var
                        money -= truckItem.Price;
                        // adding the car to a bought list to later print 
                        boughtCarList.Add(truckItem.Name, truckItem.Price);
                        Console.WriteLine($"Successfully Bought {truckItem.Name} Car for ${TruckList[convertedTruckInput].Price} \n Your remaing balance is: ${money} ");
                        // printing all the bought cars so far 
                        Car.BoughtCarPrint(boughtCarList);
                    }
                    else
                    {
                        Console.WriteLine("Sorry you do not have enough money for this car. ");
                    }

                    
                }
                else
                {
                    // if car doesnt exsit 
                   Console.WriteLine($"Invaild input car doesnt exist, please try again ");
                }
            }
            else if (input == "2")
            {
                // Printing all the Civics 
                Civic.Print(CivicList);
                Console.WriteLine("Which Truck would you like to buy? please enter the id");

                // getting user input and converting it into a int 
                string CivicInput = Console.ReadLine();
                int convertedCivicInput = (int)Convert.ToInt32(CivicInput);

                // Searching if that id exists, by passing through the list and the users input
                if (Car.SearchCivic(CivicList, convertedCivicInput))
                {
                    // because lists count starts at 0 and our id start at 1 we need to subtract 1 to get the correct object in the list 
                    if (convertedCivicInput > 1)
                    {
                        convertedCivicInput -= 1;
                    }
                    // retriving the correct item in the list 
                    Civic CivicItem = CivicList[convertedCivicInput];

                    // If user must have enough money for this car 
                    if (money >= CivicItem.Price)
                    {
                        // subtracting the amount of the car from the money var
                        money -= CivicItem.Price;
                        // adding the car to a bought list to later print 
                        boughtCarList.Add(CivicItem.Name, CivicItem.Price);
                        Console.WriteLine($"\tSuccessfully Bought {CivicItem.Name} Car for ${CivicItem.Price} \n Your remaing balance is: ${money} ");
                        // printing all the bought cars so far 
                        Car.BoughtCarPrint(boughtCarList);
                    }
                    else
                    {
                        Console.WriteLine("Sorry you do not have enough for this car>");
                    }
                }
                else
                {
                    Console.WriteLine($"Invaild input car doesnt exist, please try again ");
                }
            }
            else if (input == "3")
            {
                // Printing all the vans
                Van.Print(VanList);
                Console.WriteLine("Which Truck would you like to buy? please enter the id");

                // getting user input and converting it into a int 
                string VanInput = Console.ReadLine();
                int convertedVanInput = (int)Convert.ToInt32(VanInput);

                // Searching if that id exists, by passing through the list and the users input
                if (Car.SearchVan(VanList, convertedVanInput))
                {
                    // because lists count starts at 0 and our id start at 1 we need to subtract 1 to get the correct object in the list 
                    if (convertedVanInput > 1)
                    {
                        convertedVanInput -= 1;
                    }
                    // retriving the correct item in the list 
                    Van VanItem = VanList[convertedVanInput];

                    // If user must have enough money for this car 
                    if (money >= VanItem.Price)
                    {
                        // subtracting the amount of the car from the money var
                        money -= VanItem.Price;
                        // adding the car to a bought list to later print 
                        boughtCarList.Add(VanItem.Name, VanItem.Price);
                        Console.WriteLine($"\tSuccessfully Bought {VanItem.Name} Car for ${VanItem.Price} \n Your remaing balance is: ${money} ");
                        // printing all the bought cars so far 
                        Car.BoughtCarPrint(boughtCarList);
                    }
                    else
                    {
                        // Result if user inputs incorrect input
                        Console.WriteLine("Sorry you do not have enough for this car. ");
                    }
                }
                else
                {
                    // Result if user inputs incorrect input
                    Console.WriteLine($"Invaild input car doesnt exist, please try again ");
                }
            }
            else
            {
                // Result if user inputs incorrect input
                Console.WriteLine("Input invaid. Please enter a vaid input");
            }
        }
        public static void Sell(double money)
        {
            // Selling the created cars 
            Console.WriteLine("What car would you like to sell?");
            Console.WriteLine("1. Truck \n2. Civic \n3. Van");
            string input = Console.ReadLine();

            // Checking what kind of car the user would like to sell 
            if (input == "1")
            {
                // printing all avaiable trucks to sell
                Truck.Print(TruckList);
                Console.WriteLine("Which car would you like to sell?");
                // converting input to int to check if car exists
                string truckInput = Console.ReadLine();
                int convertedTruckInput = (int)Convert.ToInt32(truckInput);

                // searching for that car
                if(Car.SearchTruck(TruckList, convertedTruckInput))
                {
                    // Creating a new object to extract values from 
                    Truck truckItem = TruckList[convertedTruckInput];
                    // How much the car will be selling for
                    Console.WriteLine($"How much will you like to sell the car for? \n Current value ${truckItem.Price}");
                    string amountInput = Console.ReadLine();

                    // adding that sell value to the money var 
                    int convertedAmountInput = (int)Convert.ToInt32(amountInput);
                    money += convertedAmountInput;

                    // printing message saying that the car has be bought
                    Console.WriteLine($"Sold the Truck: {truckItem.Name}, for the price of: {amountInput}\nMoney: {money}");
                    
                }
                else
                {
                    // Result if invaild input 
                    Console.WriteLine("Sorry that Car doesnt exist.");
                }
                
                

            }
            else if(input == "2")
            {
                // printing all avaiable Civics to sell
                Civic.Print(CivicList);
                Console.WriteLine("Which car would you like to sell?");
                // converting input to int to check if car exists
                string CivicInput = Console.ReadLine();
                int convertedCivicInput = (int)Convert.ToInt32(CivicInput);

                // searching for that car
                if (Car.SearchCivic(CivicList, convertedCivicInput))
                {
                    // Creating a new object to extract values from 
                    Civic civicItem = CivicList[convertedCivicInput];
                    // How much the car will be selling for
                    Console.WriteLine($"How much will you like to sell the car for? \n Current value ${civicItem.Price}");
                    string amountInput = Console.ReadLine();

                    // adding that sell value to the money var 
                    int convertedAmountInput = (int)Convert.ToInt32(amountInput);
                    money += convertedAmountInput;

                    // printing message saying that the car has be bought
                    Console.WriteLine($"Sold the Civic: {civicItem.Name}, for the price of: {amountInput}\nMoney: {money}");
                }
                else
                {
                    // Result if invaild input 
                    Console.WriteLine("Sorry that Car doesnt exist.");
                }
            }
            else if(input == "3")
            {
                // printing all avaiable Vans to sell
                Van.Print(VanList);
                Console.WriteLine("Which car would you like to sell?");
                // converting input to int to check if car exists
                string VanInput = Console.ReadLine();
                int convertedVanInput = (int)Convert.ToInt32(VanInput);

                if (Car.SearchVan(VanList, convertedVanInput))
                {
                    // Creating a new object to extract values from 
                    Van VanItem = VanList[convertedVanInput];
                    // How much the car will be selling for
                    Console.WriteLine("How much will you like to sell the car for?");
                    string amountInput = Console.ReadLine();

                    // adding that sell value to the money var 
                    int convertedAmountInput = (int)Convert.ToInt32(amountInput);
                    money += convertedAmountInput;

                    // printing message saying that the car has be bought
                    Console.WriteLine($"Sold the Van: {VanItem.Name}, for the price of: {amountInput} \nMoney: {money}");
                }
                else
                {
                    // Result if invaild input 
                    Console.WriteLine("Sorry that Car doesnt exist.");
                }

            }
            else
            {
                Console.WriteLine("Please try again");
            }
        }

        public static void DetailsOfCar()
        {
            // User input of what kind of car they want to see more of 
            Console.WriteLine("What car would you like to see more information on?");
            Console.WriteLine("1. Truck \n2. Civic \n3. Van");
            string input = Console.ReadLine();

            if (input == "1")
            {
                // printing all the trucks 
                Truck.Print(TruckList);
                Console.WriteLine("Please select which car you would like to view by its id");
                string TruckInput = Console.ReadLine();
                // converting the user inputed id
                int convertedTruckInput = (int)Convert.ToInt32(TruckInput);
                //checking if that user id is real 
                if(Car.SearchTruck(TruckList, convertedTruckInput))
                {
                    // creating a place holder object to extract values from
                    Truck TruckItem = TruckList[convertedTruckInput];
                    // printing all the details of the car
                    Console.WriteLine($"Name: {TruckItem.Name}, Type: {TruckItem.Type}, Brand: {TruckItem.Brand}, Price: {TruckItem.Price} ");
                }

            }
            else if (input == "2")
            {
                // printing all the Civics
                Civic.Print(CivicList);
                Console.WriteLine("Please select which car you would like to view by its id");
                string CivicInput = Console.ReadLine();
                // converting the user inputed id
                int convertedCivicInput = (int)Convert.ToInt32(CivicInput);
                //checking if that user id is real 
                if (Car.SearchCivic(CivicList, convertedCivicInput))
                {
                    // creating a place holder object to extract values from
                    Civic CivicItem = CivicList[convertedCivicInput];
                    // printing all the details of the car
                    Console.WriteLine($"Name: {CivicItem.Name}, Brand: {CivicItem.Brand}, Price: {CivicItem.Price} ");
                }
            }
            else if(input == "3")
            {
                // printing all the Civics
                Van.Print(VanList);
                Console.WriteLine("Please select which car you would like to view by its id");
                string VanInput = Console.ReadLine();
                // converting the user inputed id
                int convertedVanInput = (int)Convert.ToInt32(VanInput);
                //checking if that user id is real 
                if (Car.SearchVan(VanList, convertedVanInput))
                {
                    // creating a place holder object to extract values from
                    Van VanItem = VanList[convertedVanInput];
                    // printing all the details of the car
                    Console.WriteLine($"Name: {VanItem.Name}, Brand: {VanItem.Brand}, Price: {VanItem.Price} ");
                }
            }
        }
    }
}
