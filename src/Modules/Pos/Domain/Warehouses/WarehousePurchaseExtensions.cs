// using System;
// using Pos.Domain.Purchases;
// using Seagull.Exceptions;

// namespace Pos.Domain.Warehouses;

// public partial  class Warehouse
// {
//     public void AddPurchase(Purchase purchase)
//     {
//         if(Purchases.Contains(purchase))
//         {
//             throw new SeagullException($"Warehouse {Name} already has a PUrchase {purchase.Number} registered");
//         }

//         Purchases.Add(purchase);
//     }
//     public void AddPurchase(List<Purchase> purchases)
//     {
//         if(purchases.Count == 0)
//         {
//             throw new SeagullException($"Theres no items in purchase list");
//         }

//         foreach(var purchase in purchases)
//         {
//             AddPurchase(purchase);
//         }
//     }
//     public void RemovePurchase(Purchase purchase)
//     {
//         var item = Purchases.FirstOrDefault(p => p == purchase) ??
//             throw new SeagullException($"Warehouse {Name} doesn't has a Purchase {purchase.Number} registered");

//         Purchases.Remove(purchase);
//     }
//     public void RemovePurchase(List<Purchase> values)
//     {
//         var unExistent =( 
//             from purchase in Purchases.ToList()
//             from value in values
//             where purchase.Id == value.Id
//             select value).Count() - values.Count;

//         if(unExistent > 0)
//         {
//             throw new SeagullException($"There are {unExistent} purchase(s) not registered in the Warehouse");
//         } 

//         foreach(var purchase in values)
//         {
//             RemovePurchase(purchase);
//         }
//     }
// }
