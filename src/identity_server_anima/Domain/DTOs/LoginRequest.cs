
namespace Identity.Domain.DTOs;

public record LoginRequest
{
    public string Login { get; set; }
    public string Senha { get; set; }
}