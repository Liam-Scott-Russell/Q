using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Q_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarQ_Backend_1.Context
{
    public class FarQContext : DbContext
    {
        // an empty constructor
        public FarQContext() { }

        // base(options) calls the base class's constructor,
        // in this case, our base class is DbContext
        public FarQContext(DbContextOptions<FarQContext> options) : base(options) { }

        // Use DbSet<Student> to query or read and 
        // write information about A Student
        public DbSet<User> User { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Booth> Booth { get; set; }
        public DbSet<EventOrganiser> EventOrganiser { get; set; }
        public DbSet<Interviewer> Interviewer { get; set; }
        public DbSet<Pool> Pool { get; set; }
        public DbSet<Queue> Queue { get; set; }

        public static System.Collections.Specialized.NameValueCollection AppSettings { get; }

        // configure the database to be used by this context
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

            // schoolSIMSConnection is the name of the key that
            // contains the has the connection string as the value
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("FarQContext"));
        }
    }
}
