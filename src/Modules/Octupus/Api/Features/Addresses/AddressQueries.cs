using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Addresses;

public sealed record GetAddress : PaginatedQueryBase;

public sealed record GetByIdAddress(string Id) : QueryBase();
