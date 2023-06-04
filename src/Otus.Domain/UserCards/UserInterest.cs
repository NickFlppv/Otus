namespace Otus.Domain.UserCards;

public class UserInterest
{
    public int UserInterestId { get; set; }
    public string Name { get; set; }
    public ICollection<UserCard> UserCards { get; set; }
}