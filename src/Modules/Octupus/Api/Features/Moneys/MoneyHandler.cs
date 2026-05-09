using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Moneys;

public class MoneyHandler(ILogger<MoneyHandler> logger)
{
    public async Task<(List<Money> Data, bool HasPreviousPage, bool HasNextPage)> Handler(
        GetMoney qry,
        [FromServices] IMoneyService service,
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
