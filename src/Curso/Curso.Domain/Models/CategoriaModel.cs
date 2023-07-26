using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domain.Models
{
    public class CategoriaModel
    {
        public int IdCategoria { get; set; }
        public string Descricao { get; set; } = default!;
    }
}
