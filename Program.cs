using System.Text.Json;

List<Vehicle> vehicleList = new List<Vehicle>();

while (true)
{
    Console.WriteLine("\n=== Vehicle Maintenance Tracker ===");

    Console.WriteLine("1. Add vehicle");
    Console.WriteLine("2. View vehicles");
    Console.WriteLine("3. Add maintenance record");
    Console.WriteLine("4. View maintenance records");
    Console.WriteLine("5. Delete vehicle");
    Console.WriteLine("6. Exit application\n");

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
                ViewMaintenanceRecords();
                break;
            case 5:
                DeleteVehicle();
                break;
            case 6:
                string fileName = "VehicleMaintenanceTracker.json";
                string jsonString = JsonSerializer.Serialize(vehicleList);
                File.WriteAllText(fileName, jsonString);
                return;
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

            Console.WriteLine("\nVehicle entered\nPress enter to return to the main menu");
            Console.ReadLine();

            break;
        }
    }

    void ViewVehicles()
    {
        Console.WriteLine();

        if (vehicleList.Count > 0)
        {
            for (int i = 0; i < vehicleList.Count; i++)
            {
                Console.WriteLine($"{i}: {vehicleList[i].Make} {vehicleList[i].Model} {vehicleList[i].Year}");
            }

            Console.WriteLine("\nPress enter to return to menu\n");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("There are no available vehicles\nPress enter to return to the main menu");
            Console.ReadLine();
        }
    }

    void AddMaintenanceRecord()
    {
        if (vehicleList.Count > 0)
        {

            Console.WriteLine("\nPlease select which vehicle you wish to add a maintenance record to\n");

            for (int i = 0; i < vehicleList.Count; i++)
            {
                Console.WriteLine($"{i}: {vehicleList[i].Make} {vehicleList[i].Model} {vehicleList[i].Year}");
            }

            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                if ((userInput < vehicleList.Count) && !(userInput < 0))
                {
                    Console.WriteLine("Please enter the maintenance that was performed on the vehicle");
                    string? maintenancePerformed = Console.ReadLine();
                    Console.WriteLine("Please enter the date the maintenance was performed - Format: MM/DD/YYYY");
                    string? maintenanceDate = Console.ReadLine();
                    Console.WriteLine("Please enter the milage of the vehicle");
                    if (!int.TryParse(Console.ReadLine(), out int miles) || (miles < 0))
                    {
                        Console.WriteLine("Invalid input\nPress enter to return to the menu");
                        Console.ReadLine();
                        return;
                    }

                    ServiceRecord serviceRecord = new ServiceRecord();

                    serviceRecord.ServicePerformed = maintenancePerformed;
                    serviceRecord.ServiceDate = maintenanceDate;
                    serviceRecord.Mileage = miles;

                    vehicleList[userInput].MaintenanceRecords.Add(serviceRecord);

                    Console.WriteLine("\nMaintenance record added\nPress Enter to return to the main menu");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid input\nPress Enter");
                    Console.ReadLine();
                }
            }
        }
        else
        {
            Console.WriteLine("\nThere are no vehicles available\nPress enter to return to the main menu");
            Console.ReadLine();
        }
    }

    void ViewMaintenanceRecords()
    {
        if (vehicleList.Count > 0)
        {
            Console.WriteLine("\nPlease select which vehicle you wish to view\n");

            for (int i = 0; i < vehicleList.Count; i++)
            {
                Console.WriteLine($"{i}: {vehicleList[i].Make} {vehicleList[i].Model} {vehicleList[i].Year}");
            }

            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                if ((userInput < vehicleList.Count) && !(userInput < 0))
                {
                    if (vehicleList[userInput].MaintenanceRecords.Count > 0)
                    {
                        foreach (var maintenanceRecord in vehicleList[userInput].MaintenanceRecords)
                        {
                            Console.WriteLine($"Service performed: {maintenanceRecord.ServicePerformed} | Service date: {maintenanceRecord.ServiceDate} | "
                                            + $"Mileage recorded at time of service: {maintenanceRecord.Mileage}");
                        }

                        Console.WriteLine("\nPress Enter to return to menu");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nThis vehicle has no maintenance record\nPress Enter to return to menu");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input\nPress enter to return to the main menu");
                    Console.ReadLine();
                }
            }
        }
        else
        {
            Console.WriteLine("\nThere are no vehicles available\nPress enter to return to the main menu");
            Console.ReadLine();
        }
    }

    void DeleteVehicle()
    {
        if (vehicleList.Count > 0)
        {
            Console.WriteLine("\nPlease enter the number of vehicle you wish to delete from the list\n");

            for (int i = 0; i < vehicleList.Count; i++)
            {
                Console.WriteLine($"{i}: {vehicleList[i].Make} {vehicleList[i].Model} {vehicleList[i].Year}");
            }

            if (int.TryParse(Console.ReadLine(), out int userInput) && (userInput < vehicleList.Count) && !(userInput < 0))
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
        }
        else
        {
            Console.WriteLine("\nThere are no vehicles available\nPress enter to return to the main menu");
            Console.ReadLine();
        }
    }
}


class Vehicle
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
    public List<ServiceRecord> MaintenanceRecords { get; } = new List<ServiceRecord>();
}

class ServiceRecord
{
    public string? ServicePerformed { get; set; }
    public string? ServiceDate { get; set; }
    public int Mileage { get; set; }
}