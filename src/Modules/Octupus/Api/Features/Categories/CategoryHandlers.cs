using System;
using Microsoft.AspNetCore.Mvc;

namespace Octupus.Api.Features.Categories;

public class CategoryHandler(ILogger<CategoryHandler> logger)
{
    public async Task<(List<Category> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
            GetCategory command,
            [FromServices] ICategoryService service,
            CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching addresses, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var entities = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        return entities.Value;
    }
}
