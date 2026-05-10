using System;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Invoices;

public class InvoiceProductEndpoints : IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/api/invoiceproduct", (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListInvoiceProducts", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetInvoiceProduct()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .Bind(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<InvoiceProduct> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<InvoiceProduct>.CreatePaginated(
                        response.Data, response.HasPreviousPage, response.HasNextPage
                    ));
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));
    }
}
