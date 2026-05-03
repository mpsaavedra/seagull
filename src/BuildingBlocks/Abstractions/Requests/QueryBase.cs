using System;

namespace Seagull.Abstractions.Requests;

public record QueryBase(bool SoftDeleted = false);
