using System;
using Microsoft.EntityFrameworkCore;
using Octupus.Api.Data.Configurations;
using Octupus.Api.Features.Addresses;
using Octupus.Api.Features.Categories;
using Octupus.Api.Features.Cities;
using Octupus.Api.Features.Customers;
using Octupus.Api.Features.Invoices;
using Octupus.Api.Features.MeasureUnits;
using Octupus.Api.Features.Moneys;
using Octupus.Api.Features.Payments;
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
    public DbSet<City> Cities => Set<City>();
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AddressConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new CityConfiguration());
        builder.ApplyConfiguration(new CurrencyConfiguration());
        builder.ApplyConfiguration(new CustomerConfiguration());
        builder.ApplyConfiguration(new CustomerPhoneConfiguration());
        builder.ApplyConfiguration(new InvoiceProductConfiguration());
        builder.ApplyConfiguration(new MeasureUnitConfiguration());
        builder.ApplyConfiguration(new MoneyConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new ProductImageConfiguration());
        builder.ApplyConfiguration(new PurchaseConfiguration());
        builder.ApplyConfiguration(new PurchaseInvoiceConfiguration());
        builder.ApplyConfiguration(new PurchaseInvoiceProductConfiguration());
        builder.ApplyConfiguration(new PurchaseProductConfiguration());
        builder.ApplyConfiguration(new SaleConfiguration());
        builder.ApplyConfiguration(new SalePaymentConfiguration());
        builder.ApplyConfiguration(new SaleProductConfiguration());
        builder.ApplyConfiguration(new StandConfiguration());
        builder.ApplyConfiguration(new StandPhoneConfiguration());
        builder.ApplyConfiguration(new StandProductConfiguration());
        builder.ApplyConfiguration(new StandSaleConfiguration());
        builder.ApplyConfiguration(new StandProductConfiguration());
        builder.ApplyConfiguration(new StandSaleConfiguration());
        builder.ApplyConfiguration(new StandSalePaymentConfiguration());
        builder.ApplyConfiguration(new StandSaleProductConfiguration());
        builder.ApplyConfiguration(new SupplierConfiguration());
        builder.ApplyConfiguration(new SupplierPhoneConfiguration());
        builder.ApplyConfiguration(new WarehouseConfiguration());
        builder.ApplyConfiguration(new WarehousePhoneConfiguration());
        builder.ApplyConfiguration(new WarehouseProductConfiguration());
    }
}
