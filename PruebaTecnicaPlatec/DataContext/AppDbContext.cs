using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PruebaTecnicaPlatec.Models;

namespace DataBaseInMemory.DataContext
{
    
        public class AppDbContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseInMemoryDatabase("MemoriaTemporal");
            }
            public DbSet<Product> Products { get; set; }
        }

        
    }
