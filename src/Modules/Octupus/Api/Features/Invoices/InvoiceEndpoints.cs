using System;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Invoices;

public class InvoiceEndpoints : IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/api/invoice", (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListInvoices", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetInvoice()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .Bind(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<Invoice> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<Invoice>.CreatePaginated(
                        response.Data, response.HasPreviousPage, response.HasNextPage
                    ));
                }));
    }
}
