using Memori_Care.Models;
using Microsoft.EntityFrameworkCore;

namespace Memori_Care.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        { }

        public DbSet<Paciente>? Pacientes { get; set;}
        public DbSet<Profissional>? Profissionais { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().UseTpcMappingStrategy();
            modelBuilder.Entity<Paciente>().ToTable("Pacientes");
            modelBuilder.Entity<Profissional>().ToTable("Profissionais");
        }

    }
}
