// using System;
// using Pos.Domain.Entities;
// using Pos.Domain.Sales;
// using Seagull.Exceptions;

// namespace Pos.Domain.Stands;

// public partial class Stand
// {
//     /// <summary>
//     /// builds a new Sale and register it
//     /// </summary>
//     /// <param name="sales"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void AddSale(DateTime saleDate, params SaleEntry[] sales)
//     {    
//         var builder = SaleBuilder.New;
//         builder.WithSaleDate(saleDate);

//         foreach(var  entry in sales)
//         {
//             if(!EnoughProductOnStockForSale(entry.Id, entry.Quantity))
//             {
//                 throw new SeagullException($"Theres not enough Product {entry.Product.Name} on Stand {Name} for a sale");
//             }            
//             builder.WithSaleEntry(entry);
//         }

//         var sale = builder.Build();

//         AddSale(sale);
//     }

//     /// <summary>
//     /// adds a sale to the area
//     /// </summary>
//     /// <param name="sale"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void AddSale(Sale sale)
//     {
//         if(Sales.Contains(sale))
//         {
//             throw new SeagullException($"Stand {Name} already has a Sale {sale.Id} registered");
//         }

//         Sales.Add(sale);
//     }

//     /// <summary>
//     /// removes a sale from this area
//     /// <remarks>This could be problematic</remarks>
//     /// </summary>
//     /// <param name="sale"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void RemoveSale(Sale sale)
//     {
//         if(!Sales.Contains(sale))
//         {
//             throw new SeagullException($"Stand {Name} doesn't has a Sale {sale.Id} registered");
//         }

//         Sales.Remove(sale);
//     }

//     /// <summary>
//     /// returns true/false if theres enough product on stock for a given operation
//     /// </summary>
//     /// <param name="productId"></param>
//     /// <param name="amount"></param>
//     /// <returns></returns>
//     /// <exception cref="SeagullException"></exception>
//     public bool EnoughProductOnStockForSale(string productId, decimal amount = 0)
//     {
//         var product = Products.FirstOrDefault(p => p.Id == productId) ?? 
//             throw new SeagullException($"Stand {Name} doesn't contain any product '{productId}'");

//         return amount > 0 ? (product.Quantity - amount) < 0 : product.Quantity > 0;
//     }
// }
