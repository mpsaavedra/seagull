using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record WarehouseDto : DtoBase
{
    public string Name { get; set; }
    public AddressDto? Address { get; set; }
    public ICollection<WarehousePhoneDto> ContactPhones { get; set; } = [];
    public bool IsAvailable { get; set; }
    public ICollection<PurchaseDto> Purchases { get; set; } = [];
    public ICollection<SaleDto> Sales { get; set; } = [];
    public ICollection<WarehouseProductDto> Products { get; set; } = [];
    public ICollection<StandProductDto> StandProducts { get; set; } = [];
    public ICollection<SaleProductDto> SaleProducts { get; set; } = [];
}


public sealed record WarehouseDetailsDto : DtoBase
{
    public string Name { get; set; }
    public AddressDetailsDto? Address { get; set; }
    public ICollection<WarehousePhoneDetailsDto> ContactPhones { get; set; } = [];
    public bool IsAvailable { get; set; }
    public ICollection<PurchaseDetailsDto> Purchases { get; set; } = [];
    public ICollection<SaleDetailsDto> Sales { get; set; } = [];
    public ICollection<WarehouseProductDetailsDto> Products { get; set; } = [];
    public ICollection<StandProductDetailsDto> StandProducts { get; set; } = [];
    public ICollection<SaleProductDetailsDto> SaleProducts { get; set; } = [];
}