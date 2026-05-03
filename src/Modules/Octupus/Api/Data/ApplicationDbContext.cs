using System;
using Microsoft.EntityFrameworkCore;
using Octupus.Api.Features.Addresses;
using Octupus.Api.Features.Categories;
using Octupus.Api.Features.Customers;
using Octupus.Api.Features.Invoices;
using Octupus.Api.Features.MeasureUnits;
using Octupus.Api.Features.Moneys;
using Octupus.Api.Features.Phones;
using Octupus.Api.Features.Products;
using Octupus.Api.Features.Purchases;
using Octupus.Api.Features.Sales;
using Octupus.Api.Features.Shippings;
using Octupus.Api.Features.Stands;
using Octupus.Api.Features.Suppliers;
using Octupus.Api.Features.Warehouses;
using Seagull.Data.EntityFrameworkCore;
using Seagull.Messaging;

namespace Octupus.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Address> addresses => Set<Address>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceProduct> invoiceProducts => Set<InvoiceProduct>();
    public DbSet<PurchaseInvoice> PurchaseInvoices => Set<PurchaseInvoice>();
    public DbSet<MeasureUnit>  MeasureUnits => Set<MeasureUnit>();
    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<Money> Moneys => Set<Money>();
    public DbSet<PurchasePayment> PurchasePayments => Set<PurchasePayment>();
    public DbSet<SalePayment> SalePayments => Set<SalePayment>();
    public DbSet<StandSalePayment> StandSalePayments => Set<StandSalePayment>();
    public DbSet<CustomerPhone> CustomerPhones => Set<CustomerPhone>();
    public DbSet<StandPhone> StandPhones => Set<StandPhone>();
    public DbSet<SupplierPhone> SupplierPhones => Set<SupplierPhone>();
    public DbSet<WarehousePhone> WarehousePhones => Set<WarehousePhone>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<PurchaseInvoiceProduct> PurchaseInvoiceProducts => Set<PurchaseInvoiceProduct>();
    public DbSet<PurchaseProduct> PurchaseProducts => Set<PurchaseProduct>();
    public DbSet<SaleProduct> SaleProducts => Set<SaleProduct>();
    public DbSet<StandProduct> StandProducts => Set<StandProduct>();
    public DbSet<StandSaleProduct> StandSaleProducts => Set<StandSaleProduct>();
    public DbSet<WarehouseProduct> WarehouseProducts => Set<WarehouseProduct>();
    public DbSet<Purchase> Purchases => Set<Purchase>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<StandSale> StandSales => Set<StandSale>();
    public DbSet<Shipping> Shippings => Set<Shipping>();
    public DbSet<Stand> Stands => Set<Stand>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
}
