using Otus.Domain.UserCards;

namespace Otus.Domain.Users;

public class User
{
    public long UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserCard? UserCard { get; set; }
    public DateTime RegisteredAt { get; set; }
    public bool IsTestAccount { get; set; }
    public bool IsBlocked { get; set; }
}