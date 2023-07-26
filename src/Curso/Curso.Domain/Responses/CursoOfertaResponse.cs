using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domain.Responses
{
    public record CursoOfertaResponse
    {
        public int IdCursoOferta { get; set; }
        public int IdCurso { get; set; }
        public string Curso { get; set; } = default!;
        public int CargaHoraria { get; set; }
        public int IdTurno { get; set; }
        public string Turno { get; set; } = default!;
        public int IdCategoria { get; set; }
        public string Categoria { get; set; } = default!;
        public int IdModelo { get; set; }
        public string Modelo { get; set; } = default!;
    }
}
