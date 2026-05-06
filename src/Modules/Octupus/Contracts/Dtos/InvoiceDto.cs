using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record InvoiceDto : DtoBase
{
    public string Number { get; protected set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public ICollection<InvoiceProductDto> Entries { get; set; } = [];
    public decimal? Tax { get; protected set; } = 0.0m;
    public decimal? Discount { get; protected set; } = 0.0m;
}
