using System;

namespace Seagull.Abstractions.Requests;

public record PaginatedQueryBase(int PageIndex = 1, int PageSize = 50) : QueryBase;
