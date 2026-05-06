using System;
using Octupus.Api.Features.Invoices;
using Octupus.Api.Features.Payments;
using Octupus.Api.Features.Products;
using Octupus.Api.Features.Purchases;
using Octupus.Contracts.Dtos;
using Seagull.Data;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Moneys;

public partial class Money : AuditableEntity, IMap<MoneyDto>
{
    public decimal Amount { get; set; }
    public string CurrentyId { get; set; }
    public Currency Currency { get; set; }
    public ICollection<InvoiceProduct> InvoiceProducts { get; set; } = [];
    public ICollection<PurchaseInvoiceProduct> PurchaseInvoiceProducts { get; set; } = [];
    public ICollection<Product> Products { get; set; } = [];
    public ICollection<StandSalePayment> StandSalePayments { get; set; } = [];
    public ICollection<PurchaseProduct> PurchaseProducts { get; set; } = [];
    public ICollection<SalePayment> SalePayments { get; set; } = [];
    public ICollection<StandSaleProduct> StandSaleProducts { get; set; } = [];
    public ICollection<StandProduct> StandProducts { get; set; } = [];
    public ICollection<SaleProduct> SaleProducts { get; set; } = [];
}
