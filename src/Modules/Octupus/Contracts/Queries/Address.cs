using Seagull.Abstractions.Requests;

namespace Octupus.Contracts.Queries;

public sealed record GetAddressQuery : PaginatedQueryBase;

public sealed record GetByIdAddressQuery(string AddressId) : QueryBase();
