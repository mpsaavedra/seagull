using System;

namespace Seagull.Abstractions.Responses;

public record ResponseBase(bool HasPreviousPage = false, bool HasNextPage = false);
