using System.ComponentModel.DataAnnotations;

namespace Nota.Domain.Models
{
    public class NotaModel
    {
        public int IdNota { get; set; }
        public int IdMatricula{ get; set; }
        public int? Nota1 { get; set; }
        public int? Nota2 { get; set; }
        public int? Nota3 { get; set; }
        public int? Media { get; set; }


        // Construtor vazio
        public NotaModel()
        {
        }

        // Construtor com parâmetros
        public NotaModel(int idNota, int idMatricula, int nota1 = 0, int nota2 = 0, int nota3 = 0, int media = 0)
        {
            IdNota = idNota;
            IdMatricula = idMatricula;
            Nota1 = nota1;
            Nota2 = nota2;
            Nota3 = nota3;
            Media = media;
        }
    }
}
