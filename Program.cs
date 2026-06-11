List<Vehicle> vehicleList = new List<Vehicle>();

while (true)
{
    Console.WriteLine("\n=== Vehicle Maintenance Tracker ===");

    Console.WriteLine("1. Add vehicle");
    Console.WriteLine("2. View vehicle");
    Console.WriteLine("3. Add maintenance record - WIP");
    Console.WriteLine("4. Delete vehicle");


    if (int.TryParse(Console.ReadLine(), out int menuSelection))
    {
        switch (menuSelection)
        {
            case 1:
                AddVehicle();
                break;
            case 2:
                ViewVehicles();
                break;
            case 3:
                AddMaintenanceRecord();
                break;
            case 4:
                DeleteVehicle();
                break;
            default:
                Console.WriteLine("Invalid option\n");
                break;

        }
    }


    void AddVehicle()
    {
        while (true)
        {
            Console.WriteLine("\nPlease enter the vehicle Make");
            string? currentVehicleMake = Console.ReadLine();

            Console.WriteLine("Please enter the vehicle Model");
            string? currentVehicleModel = Console.ReadLine();

            Console.WriteLine("Please enter the vehicle Year");
            if (!int.TryParse(Console.ReadLine(), out int currentVehicleYear))
            {
                Console.WriteLine("Invalid input\n");
                break;
            }

            Vehicle vehicle = new Vehicle();

            vehicle.Make = currentVehicleMake;
            vehicle.Model = currentVehicleModel;
            vehicle.Year = currentVehicleYear;

            vehicleList.Add(vehicle);
            break;
        }
    }

    void ViewVehicles()
    {
        /* foreach (var vehicle in vehicleList)
        {
            Console.WriteLine($"{vehicleList.Count}: {vehicle.Make} {vehicle.Model} {vehicle.Year}");
        } */

        Console.WriteLine();

        for (int i = 0; i < vehicleList.Count; i++)
        {
            Console.WriteLine($"{i}: {vehicleList[i].Make} {vehicleList[i].Model} {vehicleList[i].Year}");
        }

        Console.WriteLine("\nPress enter to return to menu\n");
        Console.ReadLine();
    }

    void AddMaintenanceRecord()
    {

    }

    void DeleteVehicle() //unfinished but functional
    {
        Console.WriteLine("\nPlease enter the number of vehicle you wish to delete from the list/n");

        for (int i = 0; i < vehicleList.Count; i++)
        {
            Console.WriteLine($"{i}: {vehicleList[i].Make} {vehicleList[i].Model} {vehicleList[i].Year}");
        }

        for (int i = vehicleList.Count - 1; i >= 0; i--)
        {
            switch (i)
            {
                case var _ when int.TryParse(Console.ReadLine(), out int userInput):
                    if (userInput <= vehicleList.Count)
                    {
                        vehicleList.RemoveAt(userInput);
                        Console.WriteLine("\nVehicle Removed\nPress Enter");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input\nPress Enter");
                        Console.ReadLine();
                    }
                    return;
                default:
                    Console.WriteLine("\nInvalid Input\nPress Enter");
                    Console.ReadLine();
                    break;
            }

        }

    }
}



class Vehicle
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
}