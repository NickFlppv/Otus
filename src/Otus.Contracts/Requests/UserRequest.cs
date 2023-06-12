namespace Otus.Contracts.Requests;

public class UserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public UserCardRequest? UserCard { get; set; }
}