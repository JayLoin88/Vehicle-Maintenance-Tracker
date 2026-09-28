# Vehicle Maintenance Tracker

## Overview

Vehicle Maintenance Tracker is a C#/.NET console application designed to help users keep track of their vehicles and maintenance history.

Users can add and manage vehicles, record maintenance services, and review maintenance records. Application data is persisted locally using JSON serialization, allowing vehicle and maintenance information to remain available between sessions.

This project was built to strengthen my understanding of C# fundamentals, object-oriented programming, collections, input validation, file persistence, and JSON serialization.

## Features

* Add vehicles with information such as make, model, and year
* View all saved vehicles
* Add maintenance records to individual vehicles
* View maintenance history for each vehicle
* Delete vehicles and their associated maintenance records
* Validate menu selections and numeric input
* Detect invalid or corrupted save data and create a backup before resetting
* Save vehicle and maintenance data using JSON serialization
* Automatically load saved data when the application starts

## Technologies

* **C#** — Core application logic and object-oriented programming
* **.NET 10** — Application runtime and framework
* **`System.Text.Json`** — JSON serialization and deserialization for data persistence

## How It Works

The application uses a menu-driven console interface that allows users to manage vehicles and their maintenance history.

Each vehicle stores its own collection of maintenance records, creating a relationship between a vehicle and the services performed on it.

Users can:

1. Add a vehicle by entering its information.
2. View the vehicles currently stored in the application.
3. Select a vehicle and add a maintenance record to it.
4. View the maintenance history associated with a selected vehicle.
5. Delete a vehicle when it is no longer needed.

User input is validated throughout the application to help prevent invalid menu selections and incorrect data from being processed.

## Data Persistence

Vehicle and maintenance data is persisted locally using JSON serialization with `System.Text.Json`.

When the application starts, it checks for an existing data file. If one is found, the JSON data is read and deserialized into the application's collection of vehicles, including their associated maintenance records.

When changes are made, the updated vehicle data is serialized and written back to the JSON file. This allows vehicle and maintenance information to remain available between application sessions.

If no existing data file is found, the application starts with an empty vehicle collection.

## What I Learned

Building the Vehicle Maintenance Tracker helped strengthen my understanding of several core C# and software development concepts, including:

* Designing and working with classes and objects
* Using collections to manage related application data
* Organizing application logic into methods
* Validating user input and handling invalid selections
* Serializing and deserializing objects with `System.Text.Json`
* Reading from and writing to files for persistent storage
* Managing relationships between objects, such as vehicles and their maintenance records
* Breaking larger application requirements into smaller, manageable pieces

This project also gave me experience taking a console application beyond basic in-memory data by implementing persistent storage, allowing information to remain available between application sessions.

## Running the Project

### Requirements

* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
* Visual Studio or another C#/.NET-compatible development environment

### Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/JayLoin88/Vehicle-Maintenance-Tracker.git
   ```

2. Navigate to the project directory:

   ```bash
   cd Vehicle-Maintenance-Tracker
   ```

3. Run the application:

   ```bash
   dotnet run
   ```

Alternatively, open the project in Visual Studio and run the application from the IDE.

No database or additional configuration is required. Application data is stored locally using JSON.

## Project Status

The Vehicle Maintenance Tracker is complete for its intended scope and is no longer under active development.

This project represents one of my earlier C#/.NET projects and demonstrates my experience with object-oriented programming, collections, input validation, JSON serialization, and file-based data persistence.

My continued development builds on these concepts through newer projects that incorporate relational databases, SQL Server, and additional application architecture practices.
