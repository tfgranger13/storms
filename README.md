Provides a report of storms that have had landfall in Florida since 1900

Utilizes HURDAT2 file from the NOAA.

Identifies storms that have made landfall in Florida and outputs a report listing the name, date of landfall, and max wind speed of the event.

This Blazor app was created with the help of the tutorials found at:
https://learn.microsoft.com/en-us/aspnet/core/blazor/tutorials

Entity Framework Core is used to create the database and database context.
SQLite is used for the database.
Google's Geocoding API was used to determine if the event made landfall in Florida.


Steps to replicate:
1. Create a new Blazor App (storms)
2. Add NuGet packages and tools to enable database integration by running the following cli commands from the project's root directory (C:\vscode_projects\storms\storms):
```
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.AspNetCore.Components.QuickGrid
dotnet add package Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
dotnet add package CsvHelper
```
3. Create a Model folder in the root directory and a model for the entity (storms.Models.Storm)
4. Scaffold the model to create the pages needed for CRUD functionality within the app by running the following cli command from the project's root directory:
```
dotnet aspnet-codegenerator blazor CRUD -dbProvider sqlite -dc Storms.Data.StormContext -m Storm -outDir Components/Pages
```
5. Create the database schema using EF Core's Migration feature by running the following cli commands from the project's root directory:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
6. Create the ETL pipeline to load the HURDAT2 data into the database and add block to Program.cs to run when the app starts

Extra scripts not needed, add seeding etl to startup
6. Install dotnet-script to allow running C# scripts by using the following cli command:
```
dotnet tool install --global dotnet-script
```

7. Create and run the ETL pipeline to load the HURDAT2 data into the database
