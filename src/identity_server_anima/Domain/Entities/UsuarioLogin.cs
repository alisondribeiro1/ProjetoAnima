using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.Entities;
public class UsuarioLogin
{
    [Key]
    public int idusuario { get; set; }

    public string login { get; set; }

    public string senha { get; set; }
}