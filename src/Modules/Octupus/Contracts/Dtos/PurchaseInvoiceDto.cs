using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record PurchaseInvoiceDto : DtoBase
{
    public PurchaseDto Purchase { get; set; }

    public string Number { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public ICollection<PurchaseInvoiceProductDto> Products { get; set; } = [];
}
