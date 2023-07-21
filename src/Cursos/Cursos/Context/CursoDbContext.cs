using Cursos.Context.Map;
using Cursos.Models;
using Microsoft.EntityFrameworkCore;

namespace Cursos.Contexto
{
    public class CursoDbContext : DbContext
    {
        public CursoDbContext(DbContextOptions<CursoDbContext> options)
            : base(options)
        {

        }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
