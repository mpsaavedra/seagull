using System;

namespace Pos.Contracts.Events;

public record CreatedProductInvoice(string ProductId, string SKU);
