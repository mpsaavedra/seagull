using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Octupus.Api.Features.Sales;

namespace Octupus.Api.Features.Payments;

public class StandSalePaymentHandler(ILogger<StandSalePaymentHandler> logger)
{
    public async Task<(List<StandSalePayment> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetStandSalePayment qry,
        [FromServices] IStandSalePaymentService service,
        CancellationToken ct = default
    )
    {
        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return response.Value;
    }
}
