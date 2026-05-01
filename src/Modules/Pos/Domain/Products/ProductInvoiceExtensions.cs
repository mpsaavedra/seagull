// using Pos.Domain.Invoices;
// using Seagull.Exceptions;

// namespace Pos.Domain.Products;

// public partial class Product
// {

//     public void AddInvoiceEntry(InvoiceEntry invoiceEntry)
//     {
//         if(!InvoiceEntries.Contains(invoiceEntry))
//         {
//             throw new SeagullException($"Product {Name} already has an invoice entry {invoiceEntry}");
//         }

//         InvoiceEntries.Add(invoiceEntry);
//     }

//     public void RemoveInvoiceEntry(InvoiceEntry invoiceEntry)
//     {
//         if(!InvoiceEntries.Contains(invoiceEntry))
//         {
//             throw new SeagullException($"Product {Name} doesn't has an invoice entry {invoiceEntry}");
//         }

//         InvoiceEntries.Remove(invoiceEntry);
//     }
// }
