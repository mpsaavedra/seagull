// using System;
// using Pos.Domain.Products;
// using Seagull.Exceptions;

// namespace Pos.Domain.Warehouses;

// public partial class Warehouse
// {
//     /// <summary>
//     /// gets true if there are any product how need to re-order
//     /// </summary>
//     public bool NeedToReOrderProducts => ProductsInReOrderLevel.Any();

//     /// <summary>
//     /// gets the list of products that need to be re-ordered
//     /// </summary>
//     public ICollection<Product> ProductsInReOrderLevel =>
//         [.. (
//             from product in Products.ToList()
//             where product.ReOrderRevel > 0 && product.Quantity <= product.ReOrderRevel
//             select product
//         )];

//     /// <summary>
//     /// gets the list of products that are abut to expire in certain amount of days, default value is 30 days
//     /// </summary>
//     /// <param name="days"></param>
//     /// <returns></returns>
//     /// <exception cref="SeagullException"></exception>
//     public ICollection<Product> ProductAboutToExpire(int days = 30)
//     {
//         if(days < 0)
//             throw new SeagullException("Expiration days could be less that 0");

//         return 
//             [..(
//                 from product in Products.ToList()
//                 where product.OnStock && product.ExpirationDate is not null && product.ExpirationDate <= DateTime.UtcNow.AddDays(days)
//                 select product
//             )];
//     }
// }
