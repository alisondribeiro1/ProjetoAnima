using System.ComponentModel.DataAnnotations;
using Identity.Domain.Entities;

namespace Identity.Domain.ModelViews;
public class SimpleUsuarioLogin
{
    public string Login { get; set; } = default!;

    public string Senha { get; set; } = default!;

    public static SimpleUsuarioLogin Build(UsuarioLogin administrator)
    {
        return new SimpleUsuarioLogin
        { 
            Login = administrator.login, 
            Senha = administrator.senha 
        };
    }
}
