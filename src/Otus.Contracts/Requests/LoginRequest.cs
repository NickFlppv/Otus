namespace Otus.Contracts.Requests;

public class LoginRequest
{
    public long UserId { get; set; }
    public string Password { get; set; }
}