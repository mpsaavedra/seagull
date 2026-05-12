using System;
using AutoMapper;
using Octupus.Contracts.Dtos;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Categories;

public class CategoryEndpoints : IEndpointInstaller
{
    public static string ApiEndpoint = "/api/categories/";
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet(ApiEndpoint + "{id}", (IMessageBus bus, IMapper mapper, string id, CancellationToken ct = default) =>
            Result
                .Create("GetById")
                .Map(_ => new GetByIdCategory(id))
                .TryCatch(async qry =>
                {
                    var response = await bus.InvokeAsync<CategoryDetailsDto>(qry!, ct);
                    return Result.Success(mapper.Map<CategoryDetailsDto>(response));
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));

        app.MapGet(ApiEndpoint, (IMessageBus bus, IMapper mapper, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("List", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetCategory()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .TryCatch(async qry =>
                {
                    var response = await bus.InvokeAsync<(List<CategoryDto> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<CategoryDto>.CreatePaginated(
                        response.Data,
                        response.HasPreviousPage,
                        response.HasNextPage
                    ));
                })
                .Match(
                    onSuccess: value => Results.Ok(value),
                    onFailure: error => Results.BadRequest(error)
                ));
    }
}
