﻿namespace Otus.Contracts;

public class UserCardResponse
{
    public long UserCardId { get; set; }
    public long UserId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime? Birthday { get; set; }
    public string Biography { get; set; }
    public string City { get; set; }
    public GenderResponse? Gender { get; set; }
}