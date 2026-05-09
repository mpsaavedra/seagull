using System;
using Octupus.Contracts.Enums;
using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record CustomerPhoneDto : DtoBase
{
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
    public CustomerDto Customer { get; set; }
}


public sealed record CustomerPhoneDetailsDtoDto : DtoBase
{
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
    public CustomerDetailsDto Customer { get; set; }
}