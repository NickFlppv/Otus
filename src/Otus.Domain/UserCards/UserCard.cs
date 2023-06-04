using Otus.Domain.Cities;
using Otus.Domain.Genders;

namespace Otus.Domain.UserCards;

public class UserCard
{
    public long UserCardId { get; set; }
    public long UserId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public Gender? Gender { get; set; }
    public City? City { get; set; }
    public ICollection<UserInterest> Interests { get; set; }
    public bool IsDeleted { get; set; }
}