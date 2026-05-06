using Octupus.Contracts.Enums;
using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record StandPhoneDto : DtoBase
{
    public StandDto Stand { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
}
