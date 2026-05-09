using Seagull.Abstractions.Requests;

namespace Octupus.Contracts.Queries;

public sealed record GetAddress : PaginatedQueryBase;

public sealed record GetByIdAddress(string AddressId) : QueryBase();
