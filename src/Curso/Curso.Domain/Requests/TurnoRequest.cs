using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domain.Requests
{
    public record TurnoRequest
    {
        public string Descricao { get; set; } = default!;
    }
}
