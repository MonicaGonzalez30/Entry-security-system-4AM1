using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using ProyectoBack.Model;

namespace ProyectoBack.Context
{
    public class ContextoAPP : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Policia> Policia { get; set; }
        public DbSet<RegistroEntradaSalida> RegistrosEyS { get; set; }
        public DbSet<Maestro> Maestros { get; set; }
        public DbSet<Administrativo> Administrativos { get; set; }
        public DbSet<Intendencia> Intendencia { get; set; }
        public DbSet<Cafeteria> Cafeteria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=ProyectoBaseV3;user=root;password=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(a => a.boleta);
                entity.Property(a => a.password);
                entity.Property(a => a.name);
                entity.Property(a => a.apePat);
                entity.Property(a => a.apeMat);
                entity.Property(a => a.photo);
                entity.Property(a => a.estado);
            });

            modelBuilder.Entity<Policia>(entity =>
            {
                entity.HasKey(p => p.idPoli);
                entity.Property(p => p.password);
                entity.Property(p => p.name);
                entity.Property(p => p.apePat);
                entity.Property(p => p.apeMat);
                entity.Property(p => p.photo);
                entity.Property(p => p.correoPoli);
            });

            modelBuilder.Entity<RegistroEntradaSalida>(entity =>
            {
                entity.HasKey(r => r.ID);
                entity.Property(r => r.Fecha);
                entity.Property(r => r.Hora);
                entity.Property(r => r.idUsuario);
                entity.Property(r => r.TipoUsuario);
                entity.Property(r => r.Instalacion);
            });

            modelBuilder.Entity<Maestro>(entity =>
            {
                entity.HasKey(m => m.idMaestro);
                entity.Property(m => m.password);
                entity.Property(m => m.name);
                entity.Property(m => m.apePat);
                entity.Property(m => m.apeMat);
                entity.Property(m => m.photo);
            });

            modelBuilder.Entity<Administrativo>(entity =>
            {
                entity.HasKey(a => a.idAdmin);
                entity.Property(a => a.password);
                entity.Property(a => a.name);
                entity.Property(a => a.apePat);
                entity.Property(a => a.apeMat);
                entity.Property(a => a.photo);
                entity.Property(a => a.departamentoAdmin);
                entity.Property(a => a.correoAdmin);
            });

            modelBuilder.Entity<Intendencia>(entity =>
            {
                entity.HasKey(i => i.idInten);
                entity.Property(i => i.password);
                entity.Property(i => i.name);
                entity.Property(i => i.apePat);
                entity.Property(i => i.apeMat);
                entity.Property(i => i.photo);
                entity.Property(i => i.correoInten);
            });

            modelBuilder.Entity<Cafeteria>(entity =>
            {
                entity.HasKey(c => c.idCafe);
                entity.Property(c => c.password);
                entity.Property(c => c.name);
                entity.Property(c => c.apePat);
                entity.Property(c => c.apeMat);
                entity.Property(c => c.photo);
                entity.Property(c => c.correoCafe);
            });
        }
    }
}
