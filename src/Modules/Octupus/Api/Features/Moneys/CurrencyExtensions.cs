using System;
using Seagull.Extensions;

namespace Octupus.Api.Features.Moneys;

public partial class Currency
{
    public static Currency Create(string name, string? symbol = null) =>
        new() { Name = name, Symbol = symbol };

    public void Update(string? name = null, string? symbol = null)
    {
        Name = name.UpdateIfDifferent(Name);
        Symbol = symbol.UpdateIfDifferent(Symbol!);
    }
}
