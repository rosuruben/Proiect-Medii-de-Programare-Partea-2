using ClinicaVeterinaraAPI.Models; 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaraAPI.Data 
{
    public class ClinicaVeterinaraP1Context : IdentityDbContext
    {
        public ClinicaVeterinaraP1Context(DbContextOptions<ClinicaVeterinaraP1Context> options)
            : base(options)
        {
        }

        public DbSet<Proprietar> Proprietar { get; set; } = default!;
        public DbSet<Animal> Animal { get; set; } = default!;
        public DbSet<MedicVeterinar> MedicVeterinar { get; set; } = default!;
        public DbSet<Programare> Programare { get; set; } = default!;
        public DbSet<Recenzie> Recenzie { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recenzie>()
                .HasOne(r => r.Programare)
                .WithOne(p => p.Recenzie)
                .HasForeignKey<Recenzie>(r => r.ProgramareId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}