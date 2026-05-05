using System;

namespace Seagull.Abstractions.Responses;

public record ResponseBase(bool HasPreviousPage = false, bool HasNextPage = false);
public record ResponseBase<T>(IQueryable<T> Data, bool HasPreviousPage = false, bool HasNextPage = false): 
    ResponseBase(HasPreviousPage, HasNextPage);
