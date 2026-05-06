using System;
using Octupus.Api.Features.Addresses;
using Octupus.Contracts.Dtos;
using Seagull.Data;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Cities;

public partial class City : AuditableEntity, IMap<CityDto>
{
    public string Name { get; set; }
    public string? ZipCode { get; set; }
    public string Town { get; set; }
    public string State { get; set; }
    public virtual ICollection<Address> Addresses { get; set; } = [];
}
