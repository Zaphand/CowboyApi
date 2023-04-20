using CowboyApi.Classes;
using CowboyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CowboyApi.Context
{
    public class CowContext : DbContext
    {

        public DbSet<Cowboy> Cowboys { get; set; }
        public DbSet<Horse> Horses { get; set; }
        public DbSet<Gun> Guns { get; set; }
        public DbSet<PassKey> PassKeys { get; set; }

        private string DbPath { get; }

        public CowContext(IConfiguration configuration)
        {
            DbPath = configuration["ConnectionString"];
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

    }
}
