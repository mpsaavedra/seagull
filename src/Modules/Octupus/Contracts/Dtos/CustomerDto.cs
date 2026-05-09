using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record CustomerDto : DtoBase
{
    public string Name { get; set; }
    public string? ContactName { get; set; }
    public string? Email { get; set; }
    public AddressDto? Address { get; set; }
    public string? Website { get; set; }
    public string? Notes { get; set; }
    public string? CommercialNumber { get; set; }
    /// <summary>
    /// balance could be used to check for debts
    /// </summary>
    public decimal? PreviousBalance { get; set; } = 0.0m;
}

public sealed record CustomerDetailsDto : DtoBase
{
    public string Name { get; set; }
    public string? ContactName { get; set; }
    public string? Email { get; set; }
    public AddressDto? Address { get; set; }
    public string? Website { get; set; }
    public string? Notes { get; set; }
    public string? CommercialNumber { get; set; }
    /// <summary>
    /// balance could be used to check for debts
    /// </summary>
    public decimal? PreviousBalance { get; set; } = 0.0m;
    public ICollection<CustomerPhoneDto> ContactPhones { get; set; } = [];
    public ICollection<SaleDto> Sales { get; set; } = [];
}
