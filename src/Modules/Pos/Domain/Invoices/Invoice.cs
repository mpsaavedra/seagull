using System;
using System.ComponentModel.DataAnnotations.Schema;
using Pos.Domain.Invoices;
using Pos.Domain.Moneys;
using Seagull.Data;
using Seagull.Data.ValueObjects;

namespace Pos.Domain.Invoices;

/// <summary>
/// represents an Invoice, the basic values of the registered list of products, in this
/// entity all products will be enter, it uses a separate lists of products because a 
/// product  cost could change among providers and time period.
/// </summary>
public partial class Invoice : AuditableEntity
{
    protected Invoice()
    {
        Date = DateTime.UtcNow;
        Entries = new HashSet<InvoiceProduct>();
    }

    public string Number { get; protected set; }
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    public virtual ICollection<InvoiceProduct> Entries { get; set; }
    public decimal? Tax { get; protected set; }
    public decimal? Discount { get; protected set; }

    /// <summary>
    /// gets the total cost per currencies of the invoice, this is a calculation that is done
    /// in the fly and not stored in the database 
    /// </summary>
    [NotMapped]
    public ICollection<Money> TotalPrices
    {
        get
        {
            var result = new List<Money>();
            foreach(var entry in Entries)
            {
                var rEntry = result.FirstOrDefault(x => x.Currency == entry.Cost.Currency);
                if(rEntry is null)
                {
                    result.Add(entry.Cost);
                    continue;
                }
                var idx = result.IndexOf(rEntry);
                result[idx] = Money.Create(rEntry.Amount + entry.Cost.Amount, rEntry.CurrentyId);

            }
            return result;
        }
    }
}
