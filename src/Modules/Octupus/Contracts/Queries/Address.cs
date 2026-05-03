using Seagull.Abstractions.Requests;

namespace Octupus.Contracts.Queries;

public sealed record ListAllAddress() : PaginatedQueryBase;

public sealed record GetByIdAddress(string AddressId) : QueryBase;
