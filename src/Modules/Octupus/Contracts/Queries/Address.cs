using Seagull.Abstractions.Requests;

namespace Octupus.Contracts.Queries;

public sealed record GetAddressQuery(int PageIndex = 1, int PageSize = 50) : 
    PaginatedQueryBase(PageIndex, PageSize);

public sealed record GetByIdAddressQuery(string AddressId) : QueryBase();
