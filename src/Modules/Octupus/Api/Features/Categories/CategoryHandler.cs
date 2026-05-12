using System;
using AutoMapper;
using Marten;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Categories;

public class CategoryHandler(ILogger<CategoryHandler> logger)
{
    public async Task<(List<CategoryDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetCategory command,
        [FromServices] ICategoryService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Category, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);

        var count = response.Value.Data.Count;
        var mapped = (from entry in response.Value.Data select mapper.Map<CategoryDto>(entry)).ToList();
        logger.LogDebug($"Retrieving {count} Category entries");

        return (
            mapped,
            response.Value.HasPreviousPage,
            response.Value.HasNextPage
        );
    }

    public async Task<CategoryDetailsDto?> Handle(
        GetByIdCategory command,
        [FromServices] ICategoryService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Category with Id: '{command.Id}'");

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

        if (entity is null)
            return null;
        var entityDto = mapper.Map<CategoryDetailsDto>(entity);

        logger.LogDebug($"Retrieving category: {entityDto.Name}");

        return entityDto;
    }
}
