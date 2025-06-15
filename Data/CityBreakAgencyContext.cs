using CityBreaks.Agency.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Agency.Data
{
    public class CityBreakAgencyContext : DbContext
    {
        public CityBreakAgencyContext(DbContextOptions<CityBreakAgencyContext> options) 
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; } = default!;
        public DbSet<PaisDestino> PaisesDestino { get; set; } = default!;
        public DbSet<CidadeDestino> CidadesDestino { get; set; } = default!;
        public DbSet<PacoteTuristico> PacotesTuristicos { get; set; } = default!;
        public DbSet<Reserva> Reservas { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Reservas)
                .WithOne(r => r.Cliente)
                .HasForeignKey(r => r.ClienteId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PacoteTuristico>()
                .HasMany(p => p.Reservas)
                .WithOne(r => r.PacoteTuristico)
                .HasForeignKey(r => r.PacoteTuristicoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PaisDestino>()
                .HasMany(pd => pd.Cidades)
                .WithOne(cd => cd.Pais)
                .HasForeignKey(cd => cd.PaisDestinoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PacoteTuristico>()
                .HasMany(p => p.Destinos)
                .WithMany(cd => cd.PacotesTuristicos);
        }
    }
}
