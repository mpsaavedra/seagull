using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Moneys;

public class CurrencyHandler(ILogger<CurrencyHandler> logger)
{
    public async Task<(List<Currency> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetCurrency qry,
        [FromServices] ICurrencyService service,
        CancellationToken ct = default
    )
    {
        logger.LogInformation($"eFetching Currencies, PageIndex: {qry.PageIndex}, PAgeSize: {qry.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: false,
            cancellationToken: ct
        );
        return response.Value;
    }
}
