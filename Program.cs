List<Vehicle> vehicleList = new List<Vehicle>();

while (true)
{
    Console.WriteLine("=== Vehicle Maintenance Tracker ===");

    Console.WriteLine("1. Add vehicle");
    Console.WriteLine("2. View vehicle");


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
        }
    }
    else
    {
        Console.WriteLine("Invalid option");
    }


    void AddVehicle()
    {
        while (true)
        {
            Console.WriteLine("Please enter the vehicle Make");
            string? currentVehicleMake = Console.ReadLine();

            Console.WriteLine("Please enter the vehicle Model");
            string? currentVehicleModel = Console.ReadLine();

            Console.WriteLine("Please enter the vehicle Year");
            if (!int.TryParse(Console.ReadLine(), out int currentVehicleYear))
            {
                Console.WriteLine("Invalid input");
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

    void DeleteVehicle()
    {

    }
}



class Vehicle
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
}