using Otus.DataAccess.Abstractions;

namespace Otus.Postgres.Dtos;

public class UserCardDto : IDataAccessDto
{
    public long UserCardId { get; set; }
    public long UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public string Biography { get; set; }
    public int GenderId { get; set; }
    public GenderDto? Gender { get; set; }
    public string City { get; set; }
}