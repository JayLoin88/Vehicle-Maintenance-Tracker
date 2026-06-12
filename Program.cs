List<Vehicle> vehicleList = new List<Vehicle>();

while (true)
{
    Console.WriteLine("\n=== Vehicle Maintenance Tracker ===");

    Console.WriteLine("1. Add vehicle");
    Console.WriteLine("2. View vehicles");
    Console.WriteLine("3. Add maintenance record");
    Console.WriteLine("4. View maintenance record");
    Console.WriteLine("5. Delete vehicle");


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
                ViewMaintenanceRecord();
                break;
            case 5:
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
            Console.WriteLine($"{i}: {vehicleList[i].Make} {vehicleList[i].Model} {vehicleList[i].Year} \tLast recorded maintenance: {vehicleList[i].vehicleMaintenanceRecord.FirstOrDefault()}");
        }

        Console.WriteLine("\nPress enter to return to menu\n");
        Console.ReadLine();
    }

    void AddMaintenanceRecord()
    {
        Console.WriteLine("\nPlease select which vehicle you wish to add a maintenance record to\n");

        for (int i = 0; i < vehicleList.Count; i++)
        {
            Console.WriteLine($"{i}: {vehicleList[i].Make} {vehicleList[i].Model} {vehicleList[i].Year}");
        }

        if (int.TryParse(Console.ReadLine(), out int userInput))
        {
            if (userInput <= vehicleList.Count)
            {
                Console.WriteLine("Please enter the maintenance that was performed on the vehicle");
                string? maintenancePerformed = Console.ReadLine();
                Console.WriteLine("Please enter the date the maintenance was performed - Format: MM/DD/YYYY");
                string? maintenanceDate = Console.ReadLine();

                string maintenanceRecorded = maintenancePerformed + " " + maintenanceDate;

                vehicleList[userInput].vehicleMaintenanceRecord.Add(maintenanceRecorded);
            }
            else
            {
                Console.WriteLine("Invalid input\nPress Enter");
                Console.ReadLine();
            }
        }
    }

    void ViewMaintenanceRecord()
    {
        Console.WriteLine("\nPlease select which vehicle you wish to view\n");

        for (int i = 0; i < vehicleList.Count; i++)
        {
            Console.WriteLine($"{i}: {vehicleList[i].Make} {vehicleList[i].Model} {vehicleList[i].Year}");
        }

        if (int.TryParse(Console.ReadLine(), out int userInput))
        {
            if (userInput <= vehicleList.Count)
            {
                foreach (var maintenanceRecord in vehicleList[userInput].vehicleMaintenanceRecord)
                {
                    Console.WriteLine(maintenanceRecord);
                }

                Console.WriteLine("\nPress Enter to return to menu\n");
                Console.ReadLine();
            }
        }
    }

    void DeleteVehicle() //unfinished but functional | second for loop needs to be changed to avoid unreachable code
    {
        Console.WriteLine("\nPlease enter the number of vehicle you wish to delete from the list\n");

        for (int i = 0; i < vehicleList.Count; i++)
        {
            Console.WriteLine($"{i}: {vehicleList[i].Make} {vehicleList[i].Model} {vehicleList[i].Year} Last recorded maintenance: {vehicleList[i].vehicleMaintenanceRecord.LastOrDefault()}");
        }

        for (int i = vehicleList.Count - 1; i >= 0; i--) // conditional if statement or while loop will be an improvement over a for loop
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
                    return; // for loop becomes unreachable when default case is set to return instead of break
            }

        }

    }
}



class Vehicle
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
    public List<string> vehicleMaintenanceRecord { get; } = new List<string>();
}