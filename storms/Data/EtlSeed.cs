using Microsoft.EntityFrameworkCore;
using storms.Models;
using Storms.Data;

namespace storms.Data;

public class EtlSeed
{
    /* 
    This method is called from Program.cs to seed the database when the server is started for the first time.
    It will read the parsed HURDAT2 csv file from the ETL pipeline and add to the database.
    This data will be displayed on the site in a table and available for download as a CSV file.
    It is not a continuous pipeline, so any additional files that need to be processed using the ETL pipeline
    and will require changes to this code and a redeploy of the application.
    */
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new StormContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<StormContext>>());

        if (context == null || context.Storm == null)
        {
            throw new NullReferenceException(
                "Null StormsContext or Storm DbSet");
        }

        if (context.Storm.Any())
        {
            // return; // does not run code below if any data already exists in the database

            // While testing, clear out existing data to reprocess the input
            context.Storm.RemoveRange(context.Storm);
            context.SaveChanges();
        }

        List<Storm> dataStorms = [];
        // string filePath = "wwwroot\\Data\\py_parsed_landfall_identifier.csv";
        string filePath = "wwwroot\\Data\\py_parsed_rev_geo.csv";
        var lines = File.ReadAllLines(filePath);
        var dataLines = lines.Skip(1); // Skip header line
        foreach (var line in dataLines)
        {
            var fields = line.Split(',');
            dataStorms.Add(new Storm
            {
                Id = fields[0],
                Name = fields[1],
                LandfallDate = DateOnly.ParseExact(fields[2], "yyyy-MM-dd"),
                MaxWindSpeed = int.Parse(fields[3])
            });
        }

        context.Storm.AddRange(dataStorms);
        context.SaveChanges();
    }
}
