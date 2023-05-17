using Otus.DataAccess.Abstractions;
using Otus.Domain.UserCards;

namespace Otus.Postgres.Dtos;

public class UserCardDto : IDataAccessDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public GenderDto? Gender { get; set; }
    public CityDto? City { get; set; }
    public ICollection<UserInterest> Interests { get; set; }
    public bool IsDeleted { get; set; }
}