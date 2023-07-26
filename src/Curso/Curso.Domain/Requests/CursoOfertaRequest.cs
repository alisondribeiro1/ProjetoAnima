using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domain.Requests
{
    public class CursoOfertaRequest
    {
        public string Curso { get; set; } = default!;
        public string Categoria{ get; set; } = default!;
        public string Modelo { get; set; } = default!;
        public string Turno { get; set; } = default!;
    }
}
