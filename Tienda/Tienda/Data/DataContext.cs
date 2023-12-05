using Microsoft.EntityFrameworkCore;
using Tienda.Data.Entities;

namespace Tienda.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
      
        }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("Name","countryId").IsUnique(); //Indice compuesto por la relacion 1 a muchos
            modelBuilder.Entity<City>().HasIndex("Name", "stateId").IsUnique(); //Indice compuesto por la relacion 1 a muchos
        }
    }
}
