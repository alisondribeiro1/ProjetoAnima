using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domain.Models
{
    public class TurnoModel
    {
        public int IdTurno { get; set; }
        public string Descricao{ get; set; } = default!;
    }
}

