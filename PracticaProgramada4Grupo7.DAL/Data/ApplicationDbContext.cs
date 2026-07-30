using Microsoft.EntityFrameworkCore;
using PracticaProgramada4Grupo7.DAL.Entidades;

namespace PracticaProgramada4Grupo7.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estudiante>(entidad =>
            {
                entidad.HasKey(e => e.Id);

                entidad.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(20);

                entidad.HasIndex(e => e.Cedula)
                    .IsUnique();

                entidad.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entidad.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(100);

                entidad.Property(e => e.SegundoApellido)
                    .HasMaxLength(100);

                entidad.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(150);

                entidad.HasIndex(e => e.Correo)
                    .IsUnique();

                entidad.Property(e => e.Carrera)
                    .IsRequired()
                    .HasMaxLength(150);
            });
        }
    }
}