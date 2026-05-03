using System;
using Octupus.Api.Features.Addresses;
using Seagull.Data;

namespace Octupus.Api.Features.Cities;

public partial class City : AuditableEntity
{
    public string Name { get; set; }
    public string? ZipCode { get; set; }
    public string Town { get; set; }
    public string State { get; set; }
    public virtual ICollection<Address> Addresses { get; set; } = [];
}
