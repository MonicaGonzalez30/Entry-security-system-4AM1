using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using ProyectoBack.Model;

namespace ProyectoBack.Context
{
    public class ContextoAPP : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<PersonalGeneral> PersonalG { get; set; }
        public DbSet<RegistroEntradaSalida> RegistrosEyS { get; set; }
        public DbSet<Maestro> Maestros { get; set; }
        public DbSet<Administrativo> Administrativos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=ProyectoBase;user=root;password=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(a => a.Boleta);
                entity.Property(a => a.Contraseña);
                entity.Property(a => a.NombreCompleto);
                entity.Property(a => a.Foto);
                entity.Property(a => a.EstadoActual);
            });

            modelBuilder.Entity<PersonalGeneral>(entity =>
            {
                entity.HasKey(p => p.IdentificadorDelPersonal);
                entity.Property(p => p.Contraseña);
                entity.Property(p => p.NombreCompleto);
                entity.Property(p => p.Foto);
                entity.Property(p => p.Puesto);
                entity.Property(p => p.CorreoElectronico);
            });

            modelBuilder.Entity<RegistroEntradaSalida>(entity =>
            {
                entity.HasKey(r => r.ID);
                entity.Property(r => r.Fecha);
                entity.Property(r => r.Hora);
                entity.Property(r => r.IDUsuario);
                entity.Property(r => r.TipoUsuario);
                entity.Property(r => r.Instalacion);
            });

            modelBuilder.Entity<Maestro>(entity =>
            {
                entity.HasKey(m => m.IdentificadorDeMaestro);
                entity.Property(m => m.Contraseña);
                entity.Property(m => m.NombreCompleto);
                entity.Property(m => m.Foto);
            });

            modelBuilder.Entity<Administrativo>(entity =>
            {
                entity.HasKey(a => a.IdentificadorDelAdministrativo);
                entity.Property(a => a.Contraseña);
                entity.Property(a => a.NombreCompleto);
                entity.Property(a => a.Foto);
                entity.Property(a => a.Departamento);
                entity.Property(a => a.CorreoElectronico);
            });

        }
    }
}
