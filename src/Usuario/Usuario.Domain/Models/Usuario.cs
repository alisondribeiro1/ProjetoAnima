using System.ComponentModel.DataAnnotations;

namespace Usuario.Domain.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string CPF { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public bool Administrador { get; set; }

        // Outras propriedades e métodos relacionados aos usuarios

        // Construtor vazio
       /* public UsuarioModel()
        {
        }

        // Construtor com parâmetros
        public UsuarioModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }*/
    }
}
