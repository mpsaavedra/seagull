using System;
using Seagull.Data;

namespace Pos.Domain.Moneys;

public partial class Currency : AuditableEntity
{
    public Currency()
    {
        Moneys = [];
    }
    public string Name { get;  set; }
    public string Symbol { get; set; }
    public ICollection<Money> Moneys { get; set; }
}
