using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Context
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