using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record MoneyDto : DtoBase
{
    public decimal Amount { get; set; }
    public CurrencyDto Currency { get; set; }
    public ICollection<InvoiceProductDto> InvoiceProducts { get; set; } = [];
    public ICollection<PurchaseInvoiceProductDto> PurchaseInvoiceProducts { get; set; } = [];
    public ICollection<ProductDto> Products { get; set; } = [];
    public ICollection<StandSalePaymentDto> StandSalePayments { get; set; } = [];
    public ICollection<PurchaseProductDto> PurchaseProducts { get; set; } = [];
    public ICollection<SalePaymentDto> SalePayments { get; set; } = [];
    public ICollection<StandSaleProductDto> StandSaleProducts { get; set; } = [];
    public ICollection<StandProductDto> StandProducts { get; set; } = [];
    public ICollection<SaleProductDto> SaleProducts { get; set; } = [];
}
