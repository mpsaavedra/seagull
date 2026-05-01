// using Pos.Domain.Common;
// using Pos.Domain.Products;
// using Seagull.Exceptions;
// using Seagull.Extensions;

// namespace Pos.Domain.Stands;


// public partial class Stand
// {
//     /// <summary>
//     /// adds a new product to the area and register the event
//     /// </summary>
//     /// <param name="product"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void AddProduct(Product product)
//     {
//         if(Products.Contains(product))
//         {
//             throw new SeagullException($"Stand {Name} already has Product {product.Name}");
//         }

//         Products.Add(product);
//     }

//     /// <summary>
//     /// adds a list of products to the area
//     /// </summary>
//     /// <param name="products"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void AddProduct(List<Product> products)
//     {
//         if(!products.Any())
//         {
//             throw new SeagullException($"Stand {Name} products list is empty");
//         }

//         foreach(var product in products)
//         {
//             if(Products.Contains(product))
//             {
//                 throw new SeagullException($"Stand {Name} already has Product {product.Name}");
//             }
//             Products.Add(product);
//         }
//     }


//     /// <summary>
//     /// remove a product from the area
//     /// </summary>
//     /// <param name="product"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void RemoveProduct(Product product)
//     {
//         if(!Products.Contains(product))
//         {
//             throw new SeagullException($"Stand {Name} doesn't has Product {product.Name}");
//         }

//         Products.Remove(product);
//     }

//     /// <summary>
//     /// removes a list of products from the area
//     /// </summary>
//     /// <param name="products"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void RemoveProduct(List<Product> products)
//     {
//         if(!products.Any())
//         {
//             throw new SeagullException($"Stand {Name} to remove products list is empty");
//         }

//         foreach(var product in products)
//         {
//             if(!Products.Contains(product))
//             {
//                 throw new SeagullException($"Stand {Name} doesn't has Product {product.Name}");
//             }
//             Products.Remove(product);
//         }
//     }

//     /// <summary>
//     /// register a product supply or transfer from a warehouse or other place, product must be
//     /// already register in the area before register the reception
//     /// </summary>
//     /// <param name="productId"></param>
//     /// <param name="amount"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void ReceiveProduct(string productId, decimal amount)
//     {
//         var product = Products.FirstOrDefault(p => p.Id == productId) ?? 
//             throw new SeagullException($"Stand {Name} doesn't contain any product '{productId}'");

//         product.UpdateProduct(quantity: product.Quantity + amount);
//         Products.ToUpdate(product);
//     }
//     /// <summary>
//     /// register a list of products supply or transfer from a warehouse or other place, product must be
//     /// already register in the area before register the reception
//     /// </summary>
//     /// <param name="productId"></param>
//     /// <param name="amount"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void ReceiveProduct(List<ProductMovementById> values)
//     {
//         foreach(var value in values)
//         {
//             ReceiveProduct(value.ProductId, value.Amount);
//         }
//     }

//     /// <summary>
//     /// reduce some product from stock by a transfer or other operation, product must be
//     /// already register in the area before register the deliver
//     /// </summary>
//     /// <param name="productId"></param>
//     /// <param name="amount"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void DeliverProduct(string productId, decimal amount)
//     {
//         var product = Products.FirstOrDefault(p => p.Id == productId) ?? 
//             throw new SeagullException($"Stand {Name} doesn't contain any product '{productId}'");

//         if(!EnoughProductOnStockForSale(productId, amount))
//         {
//             throw new SeagullException(
//                 $"Stand {Name}, product {product.Name} could not be deliver because there are less than {amount} products on stock");
//         }

//         product.UpdateProduct(quantity: product.Quantity - amount);
//         Products.ToUpdate(product);
//     }
//     /// <summary>
//     /// reduce a list of products from stock by a transfer or other operation, product must be
//     /// already register in the area before register the deliver
//     /// </summary>
//     /// <param name="productId"></param>
//     /// <param name="amount"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void DeliverProduct(List<ProductMovementById> values)
//     {
//         foreach(var value in values)
//         {
//             DeliverProduct(value.ProductId, value.Amount);
//         }
//     }

//     /// <summary>
//     /// returns if theres at least one product on stock
//     /// </summary>
//     /// <returns></returns>
//     public bool AnyProducOnStock() => (from product in Products where product.OnStock select product).Any();
// }
