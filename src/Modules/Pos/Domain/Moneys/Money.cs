using System;
using System.Runtime.InteropServices;
using Pos.Domain.Invoices;
using Pos.Domain.Payments;
using Pos.Domain.Products;
using Seagull.Data;

namespace Pos.Domain.Moneys;

public partial class Money : AuditableEntity
{
    public Money()
    {
        InvoiceProducts = [];
        PurchaseInvoiceProducts = [];
        Products = [];
        PurchaseProducts = [];
        SalePayments = [];
        StandSaleProducts = [];
        StandProducts = [];
        SaleProducts = [];
    }

    public static Money Create(decimal amount, string currencyId) =>
        new()
        {
            Amount = amount,
            CurrentyId = currencyId
        };

    public decimal Amount { get; set; }
    public string CurrentyId { get; set; }
    public Currency Currency { get; set; }
    public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    public ICollection<PurchaseInvoiceProduct> PurchaseInvoiceProducts { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<StandSalePayment> StandSalePayments { get; set; }
    public ICollection<PurchaseProduct> PurchaseProducts { get; set; }
    public ICollection<SalePayment> SalePayments { get; set; }
    public ICollection<StandSaleProduct> StandSaleProducts { get; set; }
    public ICollection<StandProduct> StandProducts { get; set; }
    public ICollection<SaleProduct> SaleProducts { get; set; }
}
