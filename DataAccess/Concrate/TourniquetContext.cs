using Entities.Concrate;
using Microsoft.EntityFrameworkCore;

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
    }
}