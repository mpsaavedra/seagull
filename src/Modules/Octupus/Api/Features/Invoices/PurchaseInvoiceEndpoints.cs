using System;
using Octupus.Api.Features.Purchases;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Invoices;

public class PurchaseInvoiceEndpoints : IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/api/purchaseinvoice", (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListPurchaseInvoices", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetPurchaseInvoice()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .Bind(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<PurchaseInvoice> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<PurchaseInvoice>.CreatePaginated(
                        response.Data, response.HasPreviousPage, response.HasNextPage
                    ));
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));
    }
}
