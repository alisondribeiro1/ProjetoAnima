using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domain.Requests
{
    public record CursoRequest
    {
        public string Nome { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public int CargaHoraria { get; set; }
    }
}
