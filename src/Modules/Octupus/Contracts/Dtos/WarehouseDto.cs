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


public sealed record WarehouseListDto : DtoBase
{
    public string Name { get; set; }
    public AddressListDto? Address { get; set; }
    public ICollection<WarehousePhoneListDto> ContactPhones { get; set; } = [];
    public bool IsAvailable { get; set; }
    public ICollection<PurchaseListDto> Purchases { get; set; } = [];
    public ICollection<SaleListDto> Sales { get; set; } = [];
    public ICollection<WarehouseProductListDto> Products { get; set; } = [];
    public ICollection<StandProductListDto> StandProducts { get; set; } = [];
    public ICollection<SaleProductListDto> SaleProducts { get; set; } = [];
}