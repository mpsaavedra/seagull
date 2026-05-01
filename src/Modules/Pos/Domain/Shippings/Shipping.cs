using System;
using Pos.Domain.Invoices;
using Pos.Domain.Purchases;
using Pos.Domain.Sales;
using Seagull.Data;

namespace Pos.Domain.Shippings;

public partial class Shipping : AuditableEntity
{
    /// <summary>
    /// the type of shipping
    /// </summary>
    public ShippingType ShippingType { get; set; }
    /// <summary>
    /// just used to identify the driver or any othe information about the vehicle
    /// </summary>
    public string? DriverDetails { get; set; }
    /// <summary>
    /// list of puchases in this delivery
    /// </summary>
    public ICollection<Purchase> Purchases { get; set; }
    /// <summary>
    /// gest the list of warehouse sales
    /// </summary>
    public ICollection<Sale> Sales { get; set; }
    /// <summary>
    /// gets the list of stand sales
    /// </summary>
    public ICollection<StandSale> StandSales { get; set; }
}
