using Otus.DataAccess.Abstractions;

namespace Otus.Postgres.Dtos;

public class UserDto : IDataAccessDto
{
    public long UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserCardDto? UserCard { get; set; }
    public DateTime RegisteredAt { get; set; }
    public bool IsTestAccount { get; set; }
    public bool IsBlocked { get; set; }
}