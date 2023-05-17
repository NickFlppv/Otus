namespace Otus.Contracts;

public class UserCardResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public GenderResponse? Gender { get; set; }
    public CityResponse? City { get; set; }
    public ICollection<UserInterestResponse> Interests { get; set; }
}