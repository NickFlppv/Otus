namespace Otus.Contracts.Requests;

public class UserCardRequest
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime? Birthday { get; set; }
    public string Biography { get; set; }
    public string City { get; set; }
    public int GenderId { get; set; }
}