using System;
using Microsoft.Extensions.Diagnostics.Latency;
using Octupus.Api.Features.Addresses;
using Octupus.Api.Features.Categories;
using Octupus.Api.Features.Cities;
using Octupus.Api.Features.Customers;
using Octupus.Api.Features.MeasureUnits;
using Octupus.Api.Features.Moneys;
using Octupus.Api.Features.Products;
using Octupus.Api.Features.Purchases;
using Octupus.Api.Features.Shippings;
using Octupus.Api.Features.Stands;
using Octupus.Api.Features.Suppliers;
using Octupus.Api.Features.Warehouses;
using Octupus.Contracts.Enums;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Data.Seeder;

public class OctupusSeederEndpoint : IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/seed", async (IServiceProvider provider, ILogger<OctupusSeederEndpoint> logger) =>
        {
            using var scope = provider.CreateScope();
            var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // 1 - nomenclatures
            City btno;
            City surg;
            if (!ctx.Cities.Any())
            {
                btno = City.Create("Batabano", "Batabano", "Mayabeque", "33400");
                surg = City.Create("Surgidero de Batabano", "Batabno", "Mayabeque", "33400");
                await ctx.Cities.AddRangeAsync(btno, surg);
                await ctx.SaveChangesAsync();
            }
            btno = ctx.Cities.First(x => x.Name == "Batabano");
            surg = ctx.Cities.First(x => x.Name == "Surgidero de Batabano");

            MeasureUnit meter;
            MeasureUnit centimeter;
            MeasureUnit milimeter;
            MeasureUnit unit;
            MeasureUnit box;
            MeasureUnit package;
            if (!ctx.MeasureUnits.Any())
            {
                meter = MeasureUnit.Create("Meter", "mts");
                centimeter = MeasureUnit.Create("Centimeter", "cm");
                milimeter = MeasureUnit.Create("Milimeter", "mm");
                unit = MeasureUnit.Create("Unit", "u");
                box = MeasureUnit.Create("Box", "box");
                package = MeasureUnit.Create("Package", "pkg");
                await ctx.MeasureUnits.AddRangeAsync(meter, centimeter, milimeter, unit, box, package);
                await ctx.SaveChangesAsync();
            }
            meter = ctx.MeasureUnits.First(x => x.Name == "Meter");
            centimeter = ctx.MeasureUnits.First(x => x.Name == "Centimeter");
            milimeter = ctx.MeasureUnits.First(x => x.Name == "Milimeter");
            unit = ctx.MeasureUnits.First(x => x.Name == "Unit");
            box = ctx.MeasureUnits.First(x => x.Name == "Box");
            package = ctx.MeasureUnits.First(x => x.Name == "Package");

            Currency usd;
            Currency cup;
            Currency mlc;
            if (!ctx.Currencies.Any())
            {
                usd = Currency.Create("USD Dolar", "USD");
                cup = Currency.Create("Cuban Peso", "CUP");
                mlc = Currency.Create("Free Commerce Currency", "mlc");
                await ctx.Currencies.AddRangeAsync(usd, cup, mlc);
                await ctx.SaveChangesAsync();
            }
            usd = ctx.Currencies.First(x => x.Name == "USD Dolar");
            cup = ctx.Currencies.First(x => x.Name == "Cuban Peso");
            mlc = ctx.Currencies.First(x => x.Name == "Free Commerce Currency");

            Category category1;
            Category category2;
            Category category3;
            if (!ctx.Categories.Any())
            {
                category1 = Category.Create("Category 1", "CAT-0001", "Drinks & Bevarages", "Drinks & Bevarages for Cuban Heat");
                category2 = Category.Create("Category 2", "CAT-0001", "Beers", "Drinks & Bevarages for Cuban Heat", category1.Id);
                category3 = Category.Create("Category 3", "CAT-0001", "Softdrinks", "Drinks & Bevarages for Cuban Heat", category1.Id);
                await ctx.Categories.AddRangeAsync(category1, category2, category3);
                await ctx.SaveChangesAsync();
            }
            category1 = ctx.Categories.First(x => x.Name == "Category 1");
            category2 = ctx.Categories.First(x => x.Name == "Category 2");
            category3 = ctx.Categories.First(x => x.Name == "Category 3");

            Product product1;
            Product product2;
            Product product3;
            Product product4;
            Product product5;
            Product product6;
            Product product7;
            Product product8;
            Product product9;
            Product product10;
            Product product11;
            Product product12;
            Product product13;
            Product product14;
            Product product15;
            Product product16;
            Product product17;
            Product product18;
            Product product19;
            Product product20;
            if (!ctx.Products.Any())
            {
                // TODO: Fix error at creating for Cost and MeasureUnit
                product1 = Product.Create("Drink Product 1", "PRD-DRNK-00001", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category1.Id, DateTime.UtcNow.AddMonths(10));
                product2 = Product.Create("Drink Product 2", "PRD-DRNK-00002", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category1.Id, DateTime.UtcNow.AddMonths(10));
                product3 = Product.Create("Drink Product 3", "PRD-DRNK-00003", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category1.Id, DateTime.UtcNow.AddMonths(10));
                product4 = Product.Create("Drink Product 4", "PRD-DRNK-00004", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category1.Id, DateTime.UtcNow.AddMonths(10));
                product5 = Product.Create("Drink Product 5", "PRD-DRNK-00005", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category1.Id, DateTime.UtcNow.AddMonths(10));
                product6 = Product.Create("Drink Product 6", "PRD-DRNK-00006", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category2.Id, DateTime.UtcNow.AddMonths(10));
                product7 = Product.Create("Drink Product 7", "PRD-DRNK-00007", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category2.Id, DateTime.UtcNow.AddMonths(10));
                product8 = Product.Create("Drink Product 8", "PRD-DRNK-00008", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category2.Id, DateTime.UtcNow.AddMonths(10));
                product9 = Product.Create("Drink Product 9", "PRD-DRNK-00009", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category2.Id, DateTime.UtcNow.AddMonths(10));
                product10 = Product.Create("Drink Product 10", "PRD-DRNK-000010", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category2.Id, DateTime.UtcNow.AddMonths(10));
                product11 = Product.Create("Drink Product 11", "PRD-DRNK-000011", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category2.Id, DateTime.UtcNow.AddMonths(10));
                product12 = Product.Create("Drink Product 12", "PRD-DRNK-000012", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category3.Id, DateTime.UtcNow.AddMonths(10));
                product13 = Product.Create("Drink Product 13", "PRD-DRNK-000013", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category3.Id, DateTime.UtcNow.AddMonths(10));
                product14 = Product.Create("Drink Product 14", "PRD-DRNK-000014", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category3.Id, DateTime.UtcNow.AddMonths(10));
                product15 = Product.Create("Drink Product 15", "PRD-DRNK-000015", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category3.Id, DateTime.UtcNow.AddMonths(10));
                product16 = Product.Create("Drink Product 16", "PRD-DRNK-000016", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category3.Id, DateTime.UtcNow.AddMonths(10));
                product17 = Product.Create("Drink Product 17", "PRD-DRNK-000017", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category3.Id, DateTime.UtcNow.AddMonths(10));
                product18 = Product.Create("Drink Product 18", "PRD-DRNK-000018", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category3.Id, DateTime.UtcNow.AddMonths(10));
                product19 = Product.Create("Drink Product 19", "PRD-DRNK-000019", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category3.Id, DateTime.UtcNow.AddMonths(10));
                product20 = Product.Create("Drink Product 20", "PRD-DRNK-000020", "Drinks & Beverages, the best choice to reduce heat and enjoy Cuban weather", category3.Id, DateTime.UtcNow.AddMonths(10));
                await ctx.AddRangeAsync(
                    product1, product2, product3, product4, product5, product6, product7, product8, product9, product10,
                    product11, product12, product13, product14, product15, product16, product17, product18, product19, product20
                );
                await ctx.SaveChangesAsync();
            }
            product1 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product2 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product3 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product4 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product5 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product6 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product7 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product8 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product9 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product10 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product11 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product12 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product13 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product14 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product15 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product16 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product17 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product18 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product19 = ctx.Products.First(x => x.Name == "Drink Product 1");
            product20 = ctx.Products.First(x => x.Name == "Drink Product 1");

            Address warehouseAddress;
            Address supplier1Address;
            Address supplier2Address;
            Address barAddress;
            Address bar24Address;
            Address cusstomer1Address;
            Address cusstomer2Address;
            Address cusstomer3Address;
            Address cusstomer4Address;
            Address cusstomer5Address;
            if (!ctx.Addresses.Any())
            {
                warehouseAddress = Address.Create("Street1", "Inner Address 1", btno.Id);
                supplier1Address = Address.Create("Street 2", "Inner Address 2", surg.Id);
                supplier2Address = Address.Create("Street 3", "Inner Address 3", surg.Id);
                cusstomer1Address = Address.Create("Street 4", "Inner Address 4", btno.Id);
                cusstomer2Address = Address.Create("Street 4", "Inner Address 5", surg.Id);
                cusstomer3Address = Address.Create("Street 4", "Inner Address 6", btno.Id);
                cusstomer4Address = Address.Create("Street 4", "Inner Address 7", surg.Id);
                cusstomer5Address = Address.Create("Street 4", "Inner Address 8", btno.Id);
                barAddress = Address.Create("Street 4", "Inner Address 9", surg.Id);
                bar24Address = Address.Create("Street 5", "Inner Address 10", surg.Id);
                await ctx.AddRangeAsync(
                    warehouseAddress, supplier1Address, supplier1Address,
                    cusstomer1Address, cusstomer2Address, cusstomer3Address, cusstomer4Address, cusstomer5Address,
                    barAddress, bar24Address);
                await ctx.SaveChangesAsync();
            }
            warehouseAddress = ctx.Addresses.First(x => x.Street == "Street 1");
            supplier1Address = ctx.Addresses.First(x => x.Street == "Street 2");
            supplier2Address = ctx.Addresses.First(x => x.Street == "Street 3");
            cusstomer1Address = ctx.Addresses.First(x => x.Street == "Street 4");
            cusstomer2Address = ctx.Addresses.First(x => x.Street == "Street 5");
            cusstomer3Address = ctx.Addresses.First(x => x.Street == "Street 6");
            cusstomer4Address = ctx.Addresses.First(x => x.Street == "Street 7");
            cusstomer5Address = ctx.Addresses.First(x => x.Street == "Street 8");
            barAddress = ctx.Addresses.First(x => x.Street == "Street 9");
            bar24Address = ctx.Addresses.First(x => x.Street == "Street 10");

            Stand bar;
            Stand bar24;
            if (!ctx.Stands.Any())
            {
                bar = Stand.Create("Nightfall Bar", true, "A quiet bar to last night fall drink before goes home", 20);
                bar.Address = barAddress;

                bar24 = Stand.Create("24 Horas", true, "The most popular bar in town", 150);
                bar24.Address = bar24Address;

                await ctx.AddRangeAsync(bar, bar24);
                await ctx.SaveChangesAsync();
            }
            bar = ctx.Stands.First(x => x.Name == "Nightfall Bar");
            bar24 = ctx.Stands.First(X => X.Name == "24 Horas");


            Warehouse warehouse;
            if (!ctx.WarehousePhones.Any())
            {
                warehouse = Warehouse.Create("Warehouse 001", true);
                warehouse.Address = warehouseAddress;

                await ctx.Warehouses.AddAsync(warehouse);
                await ctx.SaveChangesAsync();
            }
            warehouse = ctx.Warehouses.First(X => X.Name == "Warehouse 001");

            Supplier supplier1;
            Supplier supplier2;
            if (!ctx.Suppliers.Any())
            {
                supplier1 = Supplier.Create("Supplier 1", supplier1Address.Id);
                supplier2 = Supplier.Create("Supplier 2", supplier2Address.Id);
                await ctx.Suppliers.AddRangeAsync(supplier1, supplier2);
                await ctx.SaveChangesAsync();
            }
            supplier1 = ctx.Suppliers.First(x => x.Name == "Supplier 1");
            supplier2 = ctx.Suppliers.First(x => x.Name == "Supplier 2");

            Shipping shipping1;
            Shipping shipping2;
            if (!ctx.Shippings.Any())
            {
                shipping1 = Shipping.Create(ShippingType.Express, "Driver 1");
                shipping2 = Shipping.Create(ShippingType.Express, "Driver 2");
                await ctx.Shippings.AddRangeAsync(shipping1, shipping2);
                await ctx.SaveChangesAsync();
            }
            shipping1 = ctx.Shippings.First(x => x.DriverDetails == "Driver 1");
            shipping2 = ctx.Shippings.First(x => x.DriverDetails == "Driver 2");

            Customer customer1;
            Customer customer2;
            Customer customer3;
            Customer customer4;
            Customer customer5;
            if (!ctx.Customers.Any())
            {
                customer1 = Customer.Create("Customer 1", "Customer Number 1", "customer1@emal.com", cusstomer1Address.Id, "http://customer1.app.com", "A simple test customer");
                customer2 = Customer.Create("Customer 2", "Customer Number 2", "customer2@emal.com", cusstomer1Address.Id, "http://customer2.app.com", "A simple test customer");
                customer3 = Customer.Create("Customer 3", "Customer Number 3", "customer3@emal.com", cusstomer1Address.Id, "http://customer3.app.com", "A simple test customer");
                customer4 = Customer.Create("Customer 4", "Customer Number 4", "customer4@emal.com", cusstomer1Address.Id, "http://customer4.app.com", "A simple test customer");
                customer5 = Customer.Create("Customer 5", "Customer Number 5", "customer5@emal.com", cusstomer1Address.Id, "http://customer5.app.com", "A simple test customer");
                await ctx.Customers.AddRangeAsync(
                    customer1, customer2, customer3, customer4, customer5
                );
                await ctx.SaveChangesAsync();

            }
            customer1 = ctx.Customers.First(x => x.Name == "Customer 1");
            customer2 = ctx.Customers.First(x => x.Name == "Customer 2");
            customer3 = ctx.Customers.First(x => x.Name == "Customer 3");
            customer4 = ctx.Customers.First(x => x.Name == "Customer 4");
            customer5 = ctx.Customers.First(x => x.Name == "Customer 5");

            Purchase purchase1;
            Purchase purchase2;
            Purchase purchase3;
            if (!ctx.Purchases.Any())
            {
                purchase1 = Purchase.Create("PURCH-NMBR-0001", DateTime.UtcNow, warehouse.Id, shippingId: shipping1.Id);
                purchase1.AddProduct(
                    PurchaseProduct.Create(product1, purchase1, 10, Money.Create(20.0m, cup), supplier1),
                    PurchaseProduct.Create(product2, purchase1, 100, Money.Create(10.0m, cup), supplier1),
                    PurchaseProduct.Create(product3, purchase1, 5, Money.Create(10.0m, cup), supplier1),
                    PurchaseProduct.Create(product4, purchase1, 200, Money.Create(10.0m, cup), supplier1),
                    PurchaseProduct.Create(product5, purchase1, 10, Money.Create(100.0m, cup), supplier1),
                    PurchaseProduct.Create(product6, purchase1, 150, Money.Create(10.0m, cup), supplier1)
                );
                purchase2 = Purchase.Create("PURCH-NMBR-0001", DateTime.UtcNow, warehouse.Id, shippingId: shipping1.Id);
                purchase2.AddProduct(
                    PurchaseProduct.Create(product1, purchase1, 1000, Money.Create(25.0m, cup), supplier1),
                    PurchaseProduct.Create(product7, purchase1, 10, Money.Create(15.0m, mlc), supplier2),
                    PurchaseProduct.Create(product8, purchase1, 10, Money.Create(10.0m, mlc), supplier2),
                    PurchaseProduct.Create(product9, purchase1, 10, Money.Create(1000.0m, cup), supplier1)
                );
                purchase3 = Purchase.Create("PURCH-NMBR-0001", DateTime.UtcNow, warehouse.Id, shippingId: shipping1.Id);
                purchase3.AddProduct(
                    PurchaseProduct.Create(product10, purchase1, 10, Money.Create(7.50m, usd), supplier2),
                    PurchaseProduct.Create(product15, purchase1, 50, Money.Create(5.0m, usd), supplier2)
                );
                await ctx.Purchases.AddRangeAsync(purchase1, purchase2, purchase3);
                await ctx.SaveChangesAsync();
            }
            purchase1 = ctx.Purchases.First(x => x.Number == "");
            purchase2 = ctx.Purchases.First(x => x.Number == "");
            purchase3 = ctx.Purchases.First(x => x.Number == "");
        });
    }
}
