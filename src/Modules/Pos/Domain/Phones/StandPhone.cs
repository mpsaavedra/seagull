using System;
using Pos.Contracts.Enums;
using Pos.Domain.Stands;
using Seagull.Data;

namespace Pos.Domain.Phones;

public partial class StandPhone : AuditableEntity
{
    public string StandId { get; set; }
    public virtual Stand Stand { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
}
