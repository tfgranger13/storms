Provides a report of storms that have had landfall in Florida since 1900.

Identifies storms that have made landfall in Florida since 190.
It provides a report listing the name, date of landfall, and max wind speed of the event.
It allows users to interact with this data via web browser, file download, and API.

This Blazor app was created with the help of the tutorials found at:
https://learn.microsoft.com/en-us/aspnet/core/blazor/tutorials

Entity Framework Core is used to create the database and database context.
SQLite is used for the database.

Utilizes the free reverse geocoding API from Nominatim to determine the location of events by latitude and longitude:
https://nominatim.org/release-docs/develop/api/Reverse/

Utilizes HURDAT2 file from the NOAA:
https://www.aoml.noaa.gov/hrd/hurdat/Data_Storm.html

Steps to build locally:

Requirements:
IDE (recommended VS Code: https://code.visualstudio.com/download)
C# Dev Kit: https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp
.NET 9.0+ SDK: https://dotnet.microsoft.com/download/dotnet

1. Clone the repository to your machine.
2. Run the following CLI commands from the root directory to install the necessary packages:
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
3. Instantiate the database using the following CLI commands:
```
dotnet aspnet-codegenerator blazor -dbProvider sqlite -dc Storms.Data.StormContext -m Storm
dotnet ef migrations add InitialCreate
dotnet ef database update
```
4. Start the server (F5 in VS Code)


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
5. Create the database schema using EF Core's Migration feature by running the following cli commands from the project's root directory. These comands can also be used to update the database when changes are made to the model:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
6. Create the ETL pipeline to load the HURDAT2 data into the database and add a block to Program.cs to run the ETL script when the server starts
7. Create and run the ETL pipeline to load the HURDAT2 data into the database


To make changes to the model/database after it has been created, you will need to stop the server, then make a migration and update the database with that migration by running the following cli commands from the project's root directory:
```
dotnet ef migrations add [ReworkStormModel]
dotnet ef database update
```