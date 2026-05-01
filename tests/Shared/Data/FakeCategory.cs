using System;
using Seagull.Data;

namespace Tests.Shared.Data;

public partial class FakeCategory : AuditableEntity
{
    public string Name { get; set; }
    public ICollection<FakeBook> Books { get; set;} = [];
}
