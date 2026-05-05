using System;
using JasperFx.Core.Reflection;
using Seagull;
using Seagull.Extensions;

namespace Octupus.Api.Features.Invoices;

public partial class Invoice
{
    public static Result<Invoice> Create(string number, DateTime? date = null,
        DateTime? dueDate = null, decimal? tax = null, decimal? discount = null) =>
        Result
            .Create(new Invoice()
            {
                Number = number,
                Date = date.HasValue ? date.Value : DateTime.UtcNow,
                DueDate = dueDate,
                Tax = tax,
                Discount = discount
            });

    public Result Update(string? number = null, DateTime? date = null,
        DateTime? dueDate = null, decimal? tax = null, decimal? discount = null) =>
        Result
            .Assign(this, !number.IsNullEmptyOrWhiteSpace(), x => x.Number = number!)
            .Assign(this, date.HasValue, x => x.Date = date!.Value)
            .Assign(this, dueDate.HasValue, x => x.DueDate = dueDate!.Value)
            .Assign(this, tax.HasValue, x => x.Tax = tax!.Value)
            .Assign(this, discount.HasValue, x => x.Discount = discount!.Value);

    public Result AddProduct(InvoiceProduct product) =>
        Result
            .Check(this, x => x.Entries.Contains(product))
            .Bind(this, x => x.Entries.Add(product));

    public Result RemoveProduct(InvoiceProduct product) =>
        Result
            .Check(this, x => !x.Entries.Contains(product))
            .Bind(this, x => x.Entries.Remove(product));
}
