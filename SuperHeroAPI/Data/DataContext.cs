global using Microsoft.EntityFrameworkCore;
using System;


namespace SuperHeroAPI.Data
{
	public class DataContext : DbContext
    {
		public DataContext(DbContextOptions<DataContext> options):base(options)
		{

		}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Port=55006;Database=superherodb;Username=postgres;Password=postgrespw");
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }


    }
}

