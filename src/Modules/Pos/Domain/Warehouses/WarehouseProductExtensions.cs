// using System;
// using Microsoft.AspNetCore.Mvc;
// using Pos.Domain.Common;
// using Pos.Domain.Products;
// using Seagull.Data.ValueObjects;
// using Seagull.Exceptions;
// using Seagull.Extensions;

// namespace Pos.Domain.Warehouses;

// public partial class Warehouse
// {
//     /// <summary>
//     /// register a new product in the warehouse
//     /// </summary>
//     /// <param name="product"><see cref="Product"/>></param>
//     /// <exception cref="SeagullException"></exception>
//     public void AddProduct(Product product)
//     {
//         if(Products.Contains(product))
//         {
//             throw new SeagullException($"Warehouse {Name} already has a Product {product.Name} registered");
//         }

//         Products.Add(product);
//     }
//     /// <summary>
//     /// register a new product in the warehouse
//     /// </summary>
//     /// <param name="name"></param>
//     /// <param name="price"></param>
//     /// <param name="quantity"></param>
//     /// <param name="sku"></param>
//     /// <param name="categoryId"></param>
//     /// <param name="description"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void AddProduct(string name, Money price, decimal quantity, string sku, 
//         string categoryId, string? description = null)
//     {
//         var exits = Products.Any(p => p.Product.Name == name && p.Product.SKU == sku && p.Product.CategoryId == categoryId);
//         if(exits)
//         {
//             throw new SeagullException($"Warehouse {Name} already has a Product {name} registered");
//         }

//         Products.Add(
//             new WarehouseProduct(
//             Product.Create(name, price, quantity, sku, description, categoryId)
//         );
//     }
//     /// <summary>
//     /// remove a product from the warehouse if product doesn't exists it throws and exception
//     /// </summary>
//     /// <param name="product"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void RemoveProduct(Product product)
//     {
//         if(!Products.Contains(product))
//         {
//             throw new SeagullException($"Warehouse {Name} doesn't has a Product {product.Name} registered");
//         }

//         Products.Add(product);
//     }
//     /// <summary>
//     /// remove a product from the warehouse if product doesn't exists it throws and exception, 
//     /// using a combination of name, sku and cateoryId to avoid possible errors
//     /// </summary>
//     /// <param name="name"></param>
//     /// <param name="sku"></param>
//     /// <param name="categoryId"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void RemoveProduct(string name, string sku, string categoryId)
//     {
//         var product = Products.FirstOrDefault(p => p.Name == name && p.SKU == sku && 
//             p.CategoryId == categoryId) ?? throw new SeagullException($"Warehouse {Name} doesn't has a Product {name} registered");
            
//         Products.Remove(product);
//     }
//     /// <summary>
//     /// remove a product from the warehouse if product doesn't exists it throws and exception
//     /// </summary>
//     /// <param name="sku"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void RemoveProduct(string sku)
//     {
//         var product = Products.FirstOrDefault(p => p.SKU == sku) ??
//             throw new SeagullException($"Warehouse {Name} doesn't has a Product {sku} registered");

//         Products.Remove(product);
//     }

//     /// <summary>
//     /// receive a given product in the warehouse it throws and exception if product is not found
//     /// </summary>
//     /// <param name="productId"></param>
//     /// <param name="amount"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void ReceiveProduct(ProductMovementById value)
//     {
//         var product = Products.FirstOrDefault(p => p.Id == value.ProductId) ??
//             throw new SeagullException($"Warehouse {Name} doesn't have any product register with Id {value.ProductId}");

//         product.UpdateProduct(quantity: product.Quantity + value.Amount);
//         Products.ToUpdate(product);
//     }
//     /// <summary>
//     /// receive a list of products in the warehouse it throws and exception if product is not found
//     /// </summary>
//     /// <param name="values"></param>
//     public void ReceiveProduct(List<ProductMovementById> values)
//     {
//         var unExistent =( 
//             from product in Products.ToList()
//             from value in values
//             where product.Id == value.ProductId
//             select value).Count() - values.Count;

//         if(unExistent > 0)
//         {
//             throw new SeagullException($"There are {unExistent} products not registered in the Warehouse");
//         }    

//         foreach(var value in values)
//         {
//             ReceiveProduct(new ProductMovementById(value.ProductId, value.Amount));
//         }   
//     }
//     public void ReceiveProduct(ProductMovementBySku value)
//     {
//         var product = Products.FirstOrDefault(p => p.Id == value.Sku) ??
//             throw new SeagullException($"Warehouse {Name} doesn't have any product register with Id {value.Sku}");

//         product.UpdateProduct(quantity: product.Quantity + value.Amount);
//         Products.ToUpdate(product);
//     }
//     /// <summary>
//     /// receive a list of products in the warehouse it throws and exception if product is not found
//     /// </summary>
//     /// <param name="values"></param>
//     public void ReceiveProduct(List<ProductMovementBySku> values)
//     {
//         var unExistent =( 
//             from product in Products.ToList()
//             from value in values
//             where product.SKU == value.Sku
//             select value).Count() - values.Count;

//         if(unExistent > 0)
//         {
//             throw new SeagullException($"There are {unExistent} products not registered in the Warehouse");
//         } 

//         foreach(var value in values)
//         {
//             ReceiveProduct(new ProductMovementBySku(value.Sku, value.Amount));
//         }   
//     }
//     /// <summary>
//     /// delivers/extracts a given product from the warehouse it throws and exception if product is not found
//     /// </summary>
//     /// <param name="productId"></param>
//     /// <param name="amount"></param>
//     /// <exception cref="SeagullException"></exception>
//     public void DeliverProduct(string productId, decimal amount)
//     {
//         var product = Products.FirstOrDefault(p => p.Id == productId) ?? 
//             throw new SeagullException($"Warehouse {Name} doesn't contain any product '{productId}'");

//         if(!EnoughProductOnStockForSale(productId, amount))
//         {
//             throw new SeagullException(
//                 $"Warehouse {Name}, product {product.Name} could not be deliver because there are less than {amount} products on stock");
//         }

//         product.UpdateProduct(quantity: product.Quantity - amount);
//         Products.ToUpdate(product);
//     }
//     /// <summary>
//     /// delivers/extracts a list of products from the warehouse it throws and exception if product is not found
//     /// </summary>
//     /// <param name="values"></param>
//     public void DeliverProduct(List<ProductMovementById> values)
//     {
//         var unExistent =( 
//             from product in Products.ToList()
//             from value in values
//             where product.Id == value.ProductId
//             select value).Count() - values.Count;

//         if(unExistent > 0)
//         {
//             throw new SeagullException($"There are {unExistent} products not registered in the Warehouse");
//         } 
        
//         foreach(var value in values)
//         {
//             DeliverProduct(value.ProductId, value.Amount);
//         }
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
//             throw new SeagullException($"Warehouse {Name} doesn't contain any product '{productId}'");

//         return amount > 0 ? (product.Quantity - amount) < 0 : product.Quantity > 0;
//     }
// }
