using DOTNET.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace DOTNET.Data.Data
{
    public class MemoryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseInMemoryDatabase("StudentDb");
        }

        public DbSet<Student> Students { get; set; }
    }
}
