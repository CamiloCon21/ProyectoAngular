using InterApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InterApi.Data
{
    public class InterContext : DbContext
    {
        public InterContext(DbContextOptions<InterContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QEstudianteMat>().HasNoKey();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QMatProf>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EstudianteModel> Estudiante { get; set; }
        public DbSet<ProfesorModel> Profesor { get; set; }
        public DbSet<MateriasModel> Materias { get; set; }
        public DbSet<EstudianteMaterias> EstudianteMaterias { get; set; }
        public DbSet<ProfesorMaterias> MateriasProfesor { get; set; }
        public DbSet<QEstudianteMat> QEstudianteMats { get; set; }

        public DbSet<QMatProf> QMatProfs { get; set; }
    }
}
