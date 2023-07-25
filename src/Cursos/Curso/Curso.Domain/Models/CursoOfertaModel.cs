using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domain.Models
{
    public class CursoOfertaModel
    {
        public int IdCursoOferta { get; set; }
        public int IdCurso { get; set; }
        public CursoModel Curso { get; set; } = default!;
        public int IdTurno { get; set; }
        public TurnoModel Turno { get; set; } = default!;
        public int IdCategoria { get; set; }
        public CategoriaModel Categoria { get; set; } = default!;
        public int IdModelo { get; set; }
        public ModeloModel Modelo { get; set; } = default!;
    }
}
