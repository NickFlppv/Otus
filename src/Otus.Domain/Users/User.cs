using Otus.Domain.UserCards;

namespace Otus.Domain.Users;

public class User
{
    public long UserId { get; set; }
    public UserCard? UserCard { get; set; }
    public bool IsTestAccount { get; set; }
    public bool IsBlocked { get; set; }
}