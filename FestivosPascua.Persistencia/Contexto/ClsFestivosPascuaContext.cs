using FestivosPascua.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FestivosPascua.Persistencia.Contexto
{
    public class ClsFestivosPascuaContext : DbContext
    {
        public ClsFestivosPascuaContext(DbContextOptions<ClsFestivosPascuaContext> options)
        : base(options)
        {
        }

        public DbSet<ClsTipo> Tipos { get; set; }
        public DbSet<ClsFestivos> Festivos { get; set; }

        void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ClsTipo>(Entidad =>
            {
                Entidad.HasKey(e => e.Id);
                Entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            builder.Entity<ClsFestivos>(Entidad =>
            {
                Entidad.HasKey(e => e.Id);
                Entidad.HasIndex(e => e.Nombre).IsUnique();
                Entidad.HasIndex(e => e.Dia).IsUnique();
                Entidad.HasIndex(e => e.Mes).IsUnique();
                Entidad.HasIndex(e => e.DiasPascuas).IsUnique();
            });

            builder.Entity<ClsFestivos>()
                .HasOne(e => e.TipoDias)
                .WithMany()
                .HasForeignKey(e => e.IdTipo);
        }
    }
}
