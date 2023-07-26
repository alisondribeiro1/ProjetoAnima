namespace Identity.Domain.ModelViews;

public struct LoggedUsuarioLogin
{
    public SimpleUsuarioLogin UsuarioLogin { get;set;}
    public string Token {get;set;}
}