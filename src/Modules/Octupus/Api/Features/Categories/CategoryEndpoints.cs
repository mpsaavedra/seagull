using System;
using Seagull;
using Seagull.Abstractions.Responses;
using Seagull.Messaging;
using Seagull.ServiceInstallers;

namespace Octupus.Api.Features.Categories;

public class CategoryEndpoints : IEndpointInstaller
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/api/category", (IMessageBus bus, int pageIndex = 1, int pageSize = 50, CancellationToken ct = default) =>
            Result
                .Create("ListCategories", ErrorCodes.ApiErrors.UnProcessableRequest)
                .Map(_ => new GetCategory()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SoftDeleted = false
                })
                .Bind<GetCategory?, PaginatedResponse<Category>>(async qry =>
                {
                    if (qry is null)
                    {
                        return Result.Failure<PaginatedResponse<Category>>(
                            ErrorCodes.ApiErrors.RequestDataCouldNotBeNull
                        )!;
                    }
                    var response = await bus.InvokeAsync<(List<Category> Data, bool HasPreviousPage, bool HasNextPage)>(qry!, ct);
                    return Result.Success(PaginatedResponse<Category>.CreatePaginated(
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
