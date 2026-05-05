using System;
using Seagull;

namespace Octupus.Api;

public class ErrorCodes: Seagull.ErrorCodes
{
    public static class OctupusApi
    {
        public static readonly Error AddressStreetCouldNotBeNull                    = new ("SG-OCT-00001", "Address: field Street could not be empty or null");
        public static readonly Error AddressInnerAddressCouldNotBeNull              = new ("SG-OCT-00002", "Address: field InnerAddress could not be empty or null");
        public static readonly Error AddressCityIdCouldNotBeNull                    = new ("SG-OCT-00003", "Address: field CityId could not be empty or null");
        public static readonly Error AddressCustomerAlreadyExists                   = new ("SG-OCT-00004", "Adress already contains specified customer");
        public static readonly Error AddressCustomerDoesNotExists                   = new ("SG-OCT-00005", "Address does not contains specified customer");
        public static readonly Error AddressStandAlreadyExists                      = new ("SG-OCT-00006", "Adress already contains specified Stand");
        public static readonly Error AddressStandDoesNotExists                      = new ("SG-OCT-00007", "Address does not contains specified Stand");
        public static readonly Error AddressSupplierAlreadyExists                   = new ("SG-OCT-00008", "Adress already contains specified Supplier");
        public static readonly Error AddressSupplierDoesNotExists                   = new ("SG-OCT-00009", "Address does not contains specified Supplier");
        public static readonly Error AddressWarehouseAlreadyExists                  = new ("SG-OCT-00010", "Adress already contains specified Warehouse");
        public static readonly Error AddressWarehouseDoesNotExists                  = new ("SG-OCT-00011", "Address does not contains specified Warehouse");
        public static readonly Error CategoryChildCategoryAlreadyExists             = new ("SG-OCT-00012", "Category already contains spceified child category");
        public static readonly Error CategoryChildCategoryDoesNotExists             = new ("SG-OCT-00013", "Category does not contains spceified child category");
        public static readonly Error CategoryProductExists                          = new ("SG-OCT-00014", "Category already contains spceified product");
        public static readonly Error CategoryProductDoesNotExists                   = new ("SG-OCT-00015", "Category does not contains spceified product");
        public static readonly Error CityAddressAlreadyExists                       = new ("SG-OCT-00016", "City already contains specified address");
        public static readonly Error CityAddressDoesNotExists                       = new ("SG-OCT-00017", "City does not contains specified address");
        public static readonly Error CustomerPhoneAlreadyExists                     = new ("SG-OCT-00018", "Customer already contains specified phone");
        public static readonly Error CustomerPhoneDoesNotExists                     = new ("SG-OCT-00019", "Customer does not contains specified phone");
        public static readonly Error CustomerSaleAlreadyExists                      = new ("SG-OCT-00020", "Customer already contains specified sale");
        public static readonly Error CustomerSaleDoesNotExists                      = new ("SG-OCT-00021", "Customer does not contains specified sale");
        public static readonly Error PurchaseInvoiceProductProductAlreadyExists     = new ("SG-OCT-00022", "PurchaseInvoiceProduct already contains specified product");
        public static readonly Error PurchaseInvoiceProductProductDoesNotExists     = new ("SG-OCT-00023", "PurchaseInvoiceProduct already contains specified product");
        public static readonly Error InvoiceEntryAlreadyExists                      = new ("SG-OCT-00024", "Invoice already contains specified product entry");
        public static readonly Error InvoiceEntryDoesNotExists                      = new ("SG-OCT-00025", "Invoice does not contains specified product entry");
        public static readonly Error MeasureUnitProductAlreadyExists                = new ("SG-OCT-00026", "Measure unit already contains specified product");
        public static readonly Error MeasureUnitProductDoesNotExists                = new ("SG-OCT-00027", "Measure unit does not contains specified product");
        public static readonly Error MeasureUnitInvoiceProductAlreadyExists         = new ("SG-OCT-00028", "Measure unit already contains specified invoice product");
        public static readonly Error MeasureUnitInvoiceProductDoesNotExists         = new ("SG-OCT-00029", "Measure unit does not contains specified invoice product");
        public static readonly Error MeasureUnitPurchaseInvoiceProductAlreadyExists = new ("SG-OCT-00030", "Measure unit already contains specified purchase invoice product");
        public static readonly Error MeasureUnitPurchaseInvoiceProductDoesNotExists = new ("SG-OCT-00031", "Measure unit does not contains specified purchase invoice product");
        public static readonly Error MoneyInvoiceProductAlreadyExists               = new ("SG-OCT-00032", "Money already contains specified invoice product");
        public static readonly Error MoneyInvoiceProductDoesNotExists               = new ("SG-OCT-00033", "Money already contains specified invoice product");
        public static readonly Error MoneyPurchaseInvoiceProductAlreadyExists       = new ("SG-OCT-00034", "Money already contains specified invoice product");
        public static readonly Error MoneyPurchaseInvoiceProductDoesNotExists       = new ("SG-OCT-00035", "Money already contains specified invoice product");
        public static readonly Error MoneyProductAlreadyExists                      = new ("SG-OCT-00036", "Money already contains specified invoice product");
        public static readonly Error MoneyProductDoesNotExists                      = new ("SG-OCT-00037", "Money already contains specified invoice product");
        public static readonly Error MoneyPuchaseProductAlreadyExists               = new ("SG-OCT-00038", "Money already contains specified invoice product");
        public static readonly Error MoneyPurchaseProductDoesNotExists              = new ("SG-OCT-00039", "Money already contains specified invoice product");
        public static readonly Error MoneySalePaymentAlreadyExists                  = new ("SG-OCT-00040", "Money already contains specified invoice product");
        public static readonly Error MoneySalePaymentDoesNotExists                  = new ("SG-OCT-00041", "Money already contains specified invoice product");
        public static readonly Error MoneyStandPaymentAlreadyExists                 = new ("SG-OCT-00042", "Money already contains specified invoice product");
        public static readonly Error MoneyStandPaymentDoesNotExists                 = new ("SG-OCT-00043", "Money already contains specified invoice product");
        public static readonly Error MoneyStandSalePaymentAlreadyExists             = new ("SG-OCT-00044", "Money already contains specified invoice product");
        public static readonly Error MoneyStandSalePaymentDoesNotExists             = new ("SG-OCT-00045", "Money already contains specified invoice product");
        public static readonly Error MoneyStandSaleProductAlreadyExists             = new ("SG-OCT-00046", "Money already contains specified invoice product");
        public static readonly Error MoneyStandSaleProductDoesNotExists             = new ("SG-OCT-00047", "Money already contains specified invoice product");
        public static readonly Error MoneyStandProductAlreadyExists                 = new ("SG-OCT-00048", "Money already contains specified invoice product");
        public static readonly Error MoneyStandProductDoesNotExists                 = new ("SG-OCT-00049", "Money already contains specified invoice product"); 
        public static readonly Error AddressNotFound                                = new ("SG-OCT-00050", $"Address {0} not foind");
    }
}
