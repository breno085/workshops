
using AtasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AtasAPI.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }

        public DbSet<Colaborador> Colaboradores { get; set; }

        public DbSet<Models.Workshop> Workshops { get; set; }

        public DbSet<Presenca> Presencas { get; set; }
    }
}
