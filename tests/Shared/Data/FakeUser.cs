using System;
using Seagull.Data;

namespace Tests.Shared.Data;

public partial class FakeUser : AuditableEntity
{
    public string Username { get; set; }
    public string Name { get; set; }
}
