using System;
using AutoMapper;
using Octupus.Api.Features.Purchases;
using Octupus.Contracts.Dtos;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Invoices;

public class PurchaseInvoiceEndpoints : IEndpointInstaller
{
    public static string ApiEndpoint = "/api/purchase-invoices/";
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet(ApiEndpoint, (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListPurchaseInvoice", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetPurchaseInvoice()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .TryCatch(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<PurchaseInvoiceDto> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<PurchaseInvoiceDto>.CreatePaginated(
                        response.Data,
                        response.HasPreviousPage,
                        response.HasNextPage
                    ));
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

        app.MapGet(ApiEndpoint + "{id}", (IMessageBus bus, string id, CancellationToken ct = default) =>
            Result
                .Create("GetBydIdCustomer")
                .Map(_ => new GetByIdPurchaseInvoice(id))
                .TryCatch(async qry =>
                {
                    var response = await bus.InvokeAsync<PurchaseInvoiceDetailsDto>(qry!, ct);
                    return Result.Success(response);
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));
    }
}
