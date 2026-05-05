using System;
using Octupus.Api.Features.Invoices;
using Octupus.Api.Features.Payments;
using Octupus.Api.Features.Products;
using Octupus.Api.Features.Sales;
using Seagull;
using Seagull.Extensions;

namespace Octupus.Api.Features.Moneys;

public partial class Money
{
    public static Result<Money> Create(decimal amount, string currencyId) =>
        Result
            .Create(new Money()
            {
                Amount = amount,
                CurrentyId = currencyId
            });

    public Result Update(decimal? amount = null, string? currencyId = null) =>
        Result
            .Assign(this, amount.HasValue, x => x.Amount = amount!.Value)
            .Assign(this, !currencyId.IsNullEmptyOrWhiteSpace(), x => x.CurrentyId = currencyId!);

    public Result AddInvoiceProduct(InvoiceProduct product) =>
        Result
            .Check(this, x => x.InvoiceProducts.Contains(product), ErrorCodes.OctupusApi.MoneyInvoiceProductAlreadyExists)
            .Bind(this, x => x.InvoiceProducts.Add(product));

    public Result RemoveInvoiceProduct(InvoiceProduct product) =>
        Result
            .Check(this, x => !x.InvoiceProducts.Contains(product), ErrorCodes.OctupusApi.MoneyInvoiceProductDoesNotExists)
            .Bind(this, x => x.InvoiceProducts.Remove(product));

    public Result AddPurchaseInvoiceProduct(PurchaseInvoiceProduct product) =>
        Result
            .Check(this, x => x.PurchaseInvoiceProducts.Contains(product), ErrorCodes.OctupusApi.MoneyPurchaseInvoiceProductAlreadyExists)
            .Bind(this, x => x.PurchaseInvoiceProducts.Add(product));

    public Result RemovePurchaseInvoiceProduct(PurchaseInvoiceProduct product) =>
        Result
            .Check(this, x => !x.PurchaseInvoiceProducts.Contains(product), ErrorCodes.OctupusApi.MoneyPurchaseInvoiceProductDoesNotExists)
            .Bind(this, x => x.PurchaseInvoiceProducts.Add(product));

    public Result AddProduct(Product product) =>
        Result
            .Check(this, x => x.Products.Contains(product), ErrorCodes.OctupusApi.MoneyProductAlreadyExists)
            .Bind(this, x => x.Products.Add(product));

    public Result RemoveProduct(Product product) =>
        Result
            .Check(this, x => !x.Products.Contains(product), ErrorCodes.OctupusApi.MoneyProductDoesNotExists)
            .Bind(this, x => x.Products.Remove(product));        

    public Result AddStandSalePayment(StandSalePayment payment) =>
        Result
            .Check(this, x => x.StandSalePayments.Contains(payment), ErrorCodes.OctupusApi.MoneyStandSalePaymentAlreadyExists)
            .Bind(this, x => x.StandSalePayments.Add(payment));

    public Result RemoveStandSalePayment(StandSalePayment payment) =>
        Result
            .Check(this, x => !x.StandSalePayments.Contains(payment), ErrorCodes.OctupusApi.MoneyStandSalePaymentDoesNotExists)
            .Bind(this, x => x.StandSalePayments.Remove(payment));

    
    // public ICollection<PurchaseProduct> PurchaseProducts { get; set; } = [];
    // public ICollection<SalePayment> SalePayments { get; set; } = [];
    // public ICollection<StandSaleProduct> StandSaleProducts { get; set; } = [];
    // public ICollection<StandProduct> StandProducts { get; set; } = [];
    // public ICollection<SaleProduct> SaleProducts { get; set; } = [];
}