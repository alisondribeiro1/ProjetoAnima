using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domain.Requests
{
    public record ModeloRequest
    {
        public string Descricao { get; set; } = default!;
    }
}
