using Otus.Domain.Genders;

namespace Otus.Domain.UserCards;

public class UserCard
{
    public long UserCardId { get; set; }
    public long UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public Gender? Gender { get; set; }
    public string City { get; set; }
    public string Biography { get; set; }
}