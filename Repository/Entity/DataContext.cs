using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Repository.Entity
{
	public class DataContext : DbContext
	{
        private static bool _created = false;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        public DbSet<Item> GetItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, COD = "Testowy", Title = "pierwwszy post" },
                new Item { Id = 2, COD = "Testowy12", Title = "drugi post" },
                new Item { Id = 3, COD = "Testowyas", Title = "trzeci post" },
                new Item { Id = 4, COD = "Testowyassa", Title = "czwarty post" }
          );
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
        {
            public DataContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var dbContextBuilder = new DbContextOptionsBuilder<DataContext>();

                var connectionString = configuration.GetConnectionString("APIItems");

                dbContextBuilder.UseSqlite(connectionString);
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

                return new DataContext(dbContextBuilder.Options);
            }
        }
    }
}

