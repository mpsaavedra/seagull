using System;
using AutoMapper;
using Octupus.Api.Features.Products;
using Octupus.Contracts.Dtos;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Payments;

public class PurchasePaymentEndpoints : IEndpointInstaller
{
    public static string ApiEndpoint = "/api/purchase-payments/";
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet(ApiEndpoint, (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListPurchasePayment", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetPurchasePayment()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .TryCatch(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<PurchasePaymentDto> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<PurchasePaymentDto>.CreatePaginated(
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
                .Map(_ => new GetByIdPurchaseProduct(id))
                .TryCatch(async qry =>
                {
                    var response = await bus.InvokeAsync<PurchasePaymentDetailsDto>(qry!, ct);
                    return Result.Success(response);
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));
    }
}
