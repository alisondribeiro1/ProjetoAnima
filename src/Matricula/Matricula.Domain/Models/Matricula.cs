using System.ComponentModel.DataAnnotations;

namespace Matricula.Domain.Models
{
    public class MatriculaModel
    {
        public int IdMatricula { get; set; }
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
        public bool Ativo { get; set; }
        public bool Aprovado { get; set; }

        // Construtor vazio
        public MatriculaModel()
        {
        }

        // Construtor com parâmetros
        public MatriculaModel(int idMatricula, int idCurso, int idUsuario, bool ativo, bool aprovado)
        {
            IdMatricula = idMatricula;
            IdCurso = idCurso;
            IdUsuario = idUsuario;
            Ativo = ativo;
            Aprovado = aprovado;
        }
    }
}
