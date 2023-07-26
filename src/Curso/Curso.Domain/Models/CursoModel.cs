using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domain.Models
{
    public class CursoModel
    {
        public int idCurso { get; set; }
        public string Nome { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public int CargaHoraria { get; set; }
    }
}
