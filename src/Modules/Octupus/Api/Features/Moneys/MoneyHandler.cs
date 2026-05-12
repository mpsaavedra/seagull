using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Octupus.Api.Features.Categories;
using Octupus.Contracts.Dtos;

namespace Octupus.Api.Features.Moneys;

public class MoneyHandler(ILogger<MoneyHandler> logger)
{
    public async Task<(List<CategoryDto> Data, bool HasPreviousPage, bool HasNextPage)?> Handle(
        GetCategory command,
        [FromServices] ICategoryService service,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Fetching Categoryes, PageIndex: {command.PageIndex}, PageSize: {command.PageSize}");

        var response = await service.GetAllAsync(
            pageIndex: command.PageIndex, pageSize: command.PageSize,
            includeSoftDeleted: false, cancellationToken: cancellationToken);
        return (
            mapper.Map<List<CategoryDto>>(response.Value.Data),
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

        var entity = await service.FirstOrDefaultAsync(x => x.Id == command.Id, false, cancellationToken);
        if (entity is null)
            return null;
        var entityDto = mapper.Map<CategoryDetailsDto>(entity);
        return entityDto;
    }
}
