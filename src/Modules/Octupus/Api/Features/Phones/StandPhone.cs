using System;
using Octupus.Api.Features.Stands;
using Octupus.Contracts.Dtos;
using Octupus.Contracts.Enums;
using Seagull.Data;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Phones;

public partial class StandPhone : AuditableEntity, IMap<StandPhoneDto>
{
    public string StandId { get; set; }
    public virtual Stand Stand { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
}
