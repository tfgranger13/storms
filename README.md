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
- IDE (recommended VS Code):
    - https://code.visualstudio.com/download
- C# Dev Kit:
    - https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp
- .NET 9.0+ SDK:
    - https://dotnet.microsoft.com/download/dotnet

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
dotnet add package NSwag.AspNetCore
```
3. Instantiate the database using the following CLI commands:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
4. Start the server (F5 in VS Code from Solution Explorer)

You can test the API using Swagger UI by going to https://localhost:<port>/swagger