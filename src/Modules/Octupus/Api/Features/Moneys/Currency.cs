using System;
using Seagull.Data;

namespace Octupus.Api.Features.Moneys;

public partial class Currency : AuditableEntity
{
    public string Name { get; set; }
    public string? Symbol { get; set; }
    public ICollection<Money> Moneys { get; set; } = [];
}
