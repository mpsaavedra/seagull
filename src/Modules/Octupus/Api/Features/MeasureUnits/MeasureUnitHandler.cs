using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.MeasureUnits;

public class MeasureUnitHandler(ILogger<MeasureUnitHandler> logger)
{
    public async Task<(List<MeasureUnit> Data, bool HasPreviousPage, bool HasNextPage)> Handle(
        GetMeasureUnit qry,
        [FromServices] IMeasureUnitService service,
        CancellationToken ct = default
    )
    {
        var response = await service.GetAllAsync(
            pageIndex: qry.PageIndex,
            pageSize: qry.PageSize,
            includeSoftDeleted: qry.SoftDeleted
        );
        return response.Value;
    }
}
