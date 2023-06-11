namespace Otus.Contracts;

public class UserResponse
{
    public long UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserCardResponse? UserCard { get; set; }
    public DateTime RegisteredAt { get; set; }
    public bool IsTestAccount { get; set; }
    public bool IsBlocked { get; set; }
}