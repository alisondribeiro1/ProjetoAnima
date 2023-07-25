using Curso.Domain.Models;
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
