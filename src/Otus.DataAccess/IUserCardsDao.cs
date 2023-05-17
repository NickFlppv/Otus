﻿using Otus.Core.Models;
using Otus.DataAccess.Abstractions;

namespace Otus.DataAccess;

public interface IUserCardsDao<T> where T: class, IDataAccessDto
{
    Task<IEnumerable<T>> GetUserCards(PaginationInfo pagination);
}