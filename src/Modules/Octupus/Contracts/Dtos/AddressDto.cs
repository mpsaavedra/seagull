using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record AddressDto : DtoBase
{
    public string Street { get; set; }
    public string InnerAddress { get; set; }
    public string CityId { get; set; }
    public CityDto City { get; set; }
    public ICollection<CustomerDto> Customers { get; set; } = [];
    public ICollection<StandDto> Stands { get; set; } = [];
    public ICollection<SupplierDto> Suppliers { get; set; } = [];
    public ICollection<WarehouseDto> Warehouses { get; set; } = [];
}
