using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate
{
    public class TourniquetContext : DbContext
    {
        IConfiguration _configuration;
        public TourniquetContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Tourniquet"));
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Tourniquet> Tourniquets { get; set; }
    }
}