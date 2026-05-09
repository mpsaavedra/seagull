using Octupus.Contracts.Enums;
using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record ShippingDto : DtoBase
{
    public ShippingType ShippingType { get; set; }
    public string? DriverDetails { get; set; }
    public ICollection<PurchaseDto> Purchases { get; set; } = [];
    public ICollection<SaleDto> Sales { get; set; } = [];
    public ICollection<StandSaleDto> StandSales { get; set; } = [];
}


public sealed record ShippingDetailsDto : DtoBase
{
    public ShippingType ShippingType { get; set; }
    public string? DriverDetails { get; set; }
    public ICollection<PurchaseDetailsDto> Purchases { get; set; } = [];
    public ICollection<SaleDetailsDto> Sales { get; set; } = [];
    public ICollection<StandSaleDetailsDto> StandSales { get; set; } = [];
}