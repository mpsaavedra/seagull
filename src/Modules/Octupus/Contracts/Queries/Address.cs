using Seagull.Abstractions.Requests;

namespace Octupus.Contracts.Queries;

public sealed record GetAddressQuery(int PageIndex = 1, int PageSize = 50, bool SoftDeleted = false) : 
    PaginatedQueryBase(PageIndex, PageSize, SoftDeleted);

public sealed record GetByIdAddressQuery(string AddressId, bool SoftDeleted = false) : QueryBase(SoftDeleted);
