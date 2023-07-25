using Curso.Domain.Models;
using Curso.Infrastructure.Data.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Infrastructure.Data
{
    public class CursoDbContext : DbContext
    {
        public CursoDbContext(DbContextOptions<CursoDbContext> options) 
            : base(options) 
        {

        }
        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<ModeloModel> Modelos { get; set; }
        public DbSet<TurnoModel> Turnos { get; set; }
        public DbSet<CursoOfertaModel> CursosOfertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new CursoOfertaMap());
            modelBuilder.ApplyConfiguration(new ModeloMap());
            modelBuilder.ApplyConfiguration(new TurnoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
