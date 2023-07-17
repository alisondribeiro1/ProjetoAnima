namespace Aluno.Domain.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        // Outras propriedades e métodos relacionados aos alunos

        // Construtor vazio
        public AlunoModel()
        {
        }

        // Construtor com parâmetros
        public AlunoModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
