using Microsoft.EntityFrameworkCore;
using storms.Models;
using Storms.Data;
using System.IO;
using System.Linq;

namespace storms.Data;

public class EtlSeed
{
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
            // does not add data if any data already exists in the database
            //return;

            // For testing, clear out existing data and re-add
            context.Storm.RemoveRange(context.Storm);
            context.SaveChanges();
        }


        Storm testStorm1 = new()
        {
            Id = "AL012024",
            Basin = "AL",
            CycloneNumber = 1,
            Year = 2024,
            Name = "ARTHUR",
            Longitude = "-75.0",
            Latitude = "35.0",
            IsLandfall = true,
            LandfallDateTime = DateTime.Now,
            MaxWindSpeed = 60
        };

        Storm testStorm2 = new()
        {
            Id = "AL022024",
            Basin = "AL",
            CycloneNumber = 2,
            Year = 2024,
            Name = "BEA",
            Longitude = "14.0",
            Latitude = "15.0",
            IsLandfall = false,
            LandfallDateTime = DateTime.Now,
            MaxWindSpeed = 60
        };

        Storm testStorm3 = new()
        {
            Id = "AL032024",
            Basin = "AL",
            CycloneNumber = 3,
            Year = 2024,
            Name = "CHARLES",
            Longitude = "-75.0",
            Latitude = "-30.0",
            IsLandfall = true,
            LandfallDateTime = DateTime.Now,
            MaxWindSpeed = 60
        };

        List<Storm> testStorms = [];
        testStorms.Add(testStorm1);
        testStorms.Add(testStorm2);
        testStorms.Add(testStorm3);


        // Parse the HURDAT2 data file for storms with landfall in FL to add to the database
        // update model, there can be multiple landfall dates per storm
        string filePath = "./wwwroot/Data/HURDAT2_2025-09-26.csv";
        var lines = File.ReadAllLines(filePath);
        List<Storm> dataStorms = [];

        
        // foreach (var line in lines)
        // {
        //     string id = "";
        //     string basin = "";
        //     int cycloneNumber = 0;
        //     int year = 0;
        //     string name = "";
        //     string longitude = "";
        //     string latitude = "";
        //     bool isLandfall = false;
        //     DateTime landfallDateTime = DateTime.MinValue;
        //     int maxWindSpeed = 0;

        //     int remainingEntries = 0;
        //     int tempYear = 0;
        //     int tempMonth = 0;
        //     int tempDay = 0;
        //     int tempHour = 0;
        //     int tempMinute = 0;
        //     string tempIdentifier = "";
        //     string tempLongitude = "";
        //     string tempLatitude = "";
        //     int tempMaxWindSpeed = 0;

        //     var fields = line.Split(',');

        //     if (remainingEntries == 0) // && fields.Length == 3?
        //     {
        //         id = fields[0].Trim();
        //         basin = id[..2];
        //         cycloneNumber = int.Parse(id.Substring(2, 2));
        //         year = int.Parse(id.Substring(4, 4));
        //         name = fields[1].Trim();
        //         remainingEntries = int.Parse(fields[2].Trim());
        //     }
        //     else // if (remainingEntries > 0) // && fields.Length == 21?
        //     {
        //         tempYear = int.Parse(fields[0].Trim()[..4]);
        //         tempMonth = int.Parse(fields[0].Trim().Substring(4, 2));
        //         tempDay = int.Parse(fields[0].Trim().Substring(6, 2));
        //         tempHour = int.Parse(fields[1].Trim()[..2]);
        //         tempMinute = int.Parse(fields[1].Trim().Substring(2, 2));
        //         tempIdentifier = fields[2].Trim();
        //         tempLongitude = "";
        //         tempLatitude = "";
        //         tempMaxWindSpeed = int.Parse(fields[6].Trim());

        //         if (tempMaxWindSpeed > maxWindSpeed) maxWindSpeed = tempMaxWindSpeed;

        //         remainingEntries--;
        //     }
        // }

        List<Storm> addStorms = [];
        foreach (var s in testStorms)
        {
            if (s.IsLandfall)
            {
                addStorms.Add(s);
            }
        }

        context.Storm.AddRange(addStorms);

        context.SaveChanges();
    }
}
