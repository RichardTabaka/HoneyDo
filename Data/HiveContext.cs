using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HoneyDo.Models;



namespace HoneyDo.Data
{
    public class HiveContext : DbContext
    {
        public HiveContext(DbContextOptions<HiveContext> options) : base(options)
        {

        }

        public DbSet<Hive> Hives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example Hive for the Database
            modelBuilder.Entity<Hive>().HasData(new []
            {
                new Hive
                {
                    HiveId = 1,
                    HiveName = "Example Hive",
                    BeeCount = 10000,
                    BeeType = "Mason Bees",
                    HoneyProduced = 0,
                    Location = "Tacoma, WA"
                },
                new Hive
                {
                    HiveId = 2,
                    HiveName = "Example Hive 2",
                    HoneyProduced = 5,
                    BeeCount = 15000,
                    BeeType = "Leafcutter Bees",
                    Location = "Puyallup, WA"
                }
            }

                );


        }

    }
}
