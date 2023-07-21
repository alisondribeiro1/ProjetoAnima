using Cursos.Enums;

namespace Cursos.Models
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public string Nome { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public int CargaHoraria { get; set; }   
        public Turno Turno { get; set; } = default!;
        public Categoria Categoria { get; set; } = default!;
        public Modelo Modelo { get; set; } = default!;
    }
}
