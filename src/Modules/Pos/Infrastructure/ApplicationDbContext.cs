using System;
using Microsoft.EntityFrameworkCore;
using Pos.Domain.Categories;
using Pos.Domain.Common;
using Pos.Domain.Customers;
using Pos.Domain.Invoices;
using Pos.Domain.MeasureUnits;
using Pos.Domain.Payments;
using Pos.Domain.Phones;
using Pos.Domain.Products;
using Pos.Domain.Purchases;
using Pos.Domain.Sales;
using Pos.Domain.Suppliers;
using Pos.Domain.Warehouses;

namespace Pos.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceProduct> invoiceProducts => Set<InvoiceProduct>();
    public DbSet<PurchaseInvoice> PurchaseInvoices => Set<PurchaseInvoice>();
    public DbSet<MeasureUnit>  MeasureUnits => Set<MeasureUnit>();
    public DbSet<PurchasePayment> PurchasePayments => Set<PurchasePayment>();
    public DbSet<SalePayment> SalePayments => Set<SalePayment>();
    public DbSet<StandSalePayment> StandSalePayments => Set<StandSalePayment>();
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
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<CustomerPhone> CustomerPhones => Set<CustomerPhone>();
    public DbSet<StandPhone> StandPhones => Set<StandPhone>();
    public DbSet<SupplierPhone> SupplierPhones => Set<SupplierPhone>();
    public DbSet<WarehousePhone> WarehousePhones => Set<WarehousePhone>();
}
