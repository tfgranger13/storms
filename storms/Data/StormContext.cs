using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using storms.Models;

namespace Storms.Data
{
    public class StormContext : DbContext
    {
        public StormContext (DbContextOptions<StormContext> options)
            : base(options)
        {
        }

        public DbSet<storms.Models.Storm> Storm { get; set; } = default!;
    }
}
