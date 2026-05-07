using System;
using Microsoft.Extensions.DependencyInjection;
using Seagull.Data;
using Shouldly;
using Tests.Shared.Data;

namespace Seagull.Tests.Data;

public class UnitOfWorkTests
{
    [Fact]
    public async Task UoW_Repository_ShouldReturnAValidRepository()
    {
        // Given
        var provider = DataHelper.InitializeDataPopulated($"Repository_ValidRepository");
        var uwo = provider.GetRequiredService<IUnitOfWork>();
        var repo = uwo.Repository<FakeBook>();
        var book = await repo.FirstOrDefaultAsync(x => x.Title == "Lord of the rings I");

        // When & Then
        repo.ShouldNotBeNull();
        book.ShouldNotBeNull();
        book.HasValue.ShouldBeTrue();
        book.Value.Title.ShouldBe("Lord of the rings I");
    }

    [Fact]
    public async Task UoW_ExecuteAsync_ShouldReturnOk()
    {
        var provider = DataHelper.InitializeDataPopulated($"Repository_ValidRepository");
        var uow = provider.GetRequiredService<IUnitOfWork>();

        var result = await uow.ExecuteAsync(async () =>
        {
            try
            {
                var repo = uow.Repository<FakeBook>();
                var category = await uow.Repository<FakeCategory>().FirstOrDefaultAsync();

                category.HasValue.ShouldBeTrue();

                var res = await repo.AddAsync(new FakeBook { Title = "Test Book", Category = category.Value });
                await uow.SaveChangesAsync();
                return res;
            }
            catch
            {
                return null;
            }
        });

        result.HasNoValue.ShouldBeTrue();
        result.Value!.HasValue.ShouldBeTrue();

        var bookId = result.Value.Value;

    }
}
