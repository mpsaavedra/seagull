using System;
using System.ComponentModel;
using Seagull.Data;

namespace Tests.Shared.Data;

public partial class FakeBook : AuditableEntity
{
    public string Title { get; set; }
    public string CategoryId { get; set; }
    public FakeCategory Category { get; set; }
}
