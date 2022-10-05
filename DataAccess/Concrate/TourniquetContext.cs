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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost ; Port=5432; Database=Tourniquet ; Username=postgres ; Password=1");
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Tourniquet> Tourniquets { get; set; }

        public DbSet<Claim> Claims { get; set; }
        public DbSet<PersonOperationClaim> PersonOperationClaims { get; set; }
    }
}