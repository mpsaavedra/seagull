using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tests.Shared.Data;

namespace Seagull.Tests.Data;

public class RepositoryTests
{
    [Fact]
    public async Task Repository_FindByIdAsync_ShouldReturnEntity()
    {
        var provider = DataHelper.InitializeDataPopulated("findByIdAsync_ReturnEntity");
        var repo = provider.GetRequiredService<IFakeBookRepository>();
        var ctx = provider.GetRequiredService<FakeDbContext>();
        var user = await ctx.Users.FirstAsync();
        var entity = await repo.FindByIdAsync(user.Id);

        entity.ShouldNotBeNull();
        entity.HasValue.ShouldBeTrue();
        entity.HasNoValue.ShouldBeFalse();
        entity.Value.Id.ShouldBe(user.Id);
    }

    [Theory]
    [InlineData("Michael")] 
    [InlineData("Peter")]
    [InlineData("James")]
    [InlineData("Michel")]
    [InlineData("Jorge")]
    [InlineData("Lazaro")]
    [InlineData("Pedro")]
    [InlineData("Maria")]
    [InlineData("Mille")]
    public async Task Repository_FirstOrDefaultAsync_ShouldReturnOk(string name)
    {
        var provider = DataHelper.InitializeDataPopulated($"firstOrDefaultAsync_{name}");
        var repo = provider.GetRequiredService<IFakeUserRepository>();
        var entity = await repo.FirstOrDefaultAsync(x => x.Name == name);

        entity.ShouldNotBeNull();
        entity.HasValue.ShouldBeTrue();
        entity.HasNoValue.ShouldBeFalse();

        entity.Value.Name.ShouldBe(name);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(1)]
    [InlineData(4)]
    public async Task Repository_FirstOrDefaultAsync_ShouldReturnEntity(int amount)
    {
        var provider = DataHelper.InitializeDataPopulated($"firstOrDefaultAsync_{amount}", amount);
        var repo = provider.GetRequiredService<IFakeUserRepository>();
        var count = await repo.LongCountAsync();
        count.HasValue.ShouldBeTrue();
        count.HasNoValue.ShouldBeFalse();
        count.Value.ShouldBe(amount);
        count.ShouldBe(amount);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(4)]
    [InlineData(15)]
    [InlineData(0)]
    public async Task Repository_GetAllAsync_ShouldReturnOk(int amount)
    {
        var provider = DataHelper.InitializeDataPopulated($"GetAllAsync_{amount}", amount);
        var repo = provider.GetRequiredService<IFakeUserRepository>();
        var entities = await repo.GetAllAsync();

        entities.HasValue.ShouldBeTrue();
        entities.HasNoValue.ShouldBeFalse();

        entities.Value.Count().ShouldBe(amount);
    }

    [Theory]
    [InlineData("User 1", "username1")]
    [InlineData("User 2", "username2")]
    [InlineData("User 3", "username3")]
    [InlineData("User 4", "username4")]
    [InlineData("User 5", "username5")]
    public async Task Repository_AddAsync_ShouldReturnOk(string name, string username)
    {
        var provider = DataHelper.InitializeDataNotPopulated($"addAsync_{name}_{username}");
        var ctx = provider.GetRequiredService<FakeDbContext>();
        var repo = provider.GetRequiredService<IFakeUserRepository>();

        var id = await repo.AddAsync(new FakeUser { Name = name, Username = username});
        ctx.SaveChanges();
        var id2 = await ctx.Users.FirstAsync(x => x.Name == name);
        
        id.HasValue.ShouldBeTrue();
        id.HasNoValue.ShouldBeFalse();
        Assert.True(id.Value == id2.Id);
    }

    [Fact]
    public async Task Repository_UpdateAsync_ShouldReturnOk()
    {
        var name1 = "User One";
        var name2 = "User Modified";
        var username1 = "username1";
        var username2 = "username_modified";

        var provider = DataHelper.InitializeDataNotPopulated($"updateAsync");
        var ctx = provider.GetRequiredService<FakeDbContext>();
        var repo = provider.GetRequiredService<IFakeUserRepository>();
        var entry = await ctx.Users.AddAsync(new FakeUser { Name = name1, Username = username1 });
        var user = await ctx.Users.FirstAsync(x => x.Id == entry.Entity.Id);

        user.Name = name2;
        user.Username = username2;

        var response = await repo.UpdateAsync(user);
        ctx.SaveChanges();

        var user2 = await ctx.Users.FirstAsync(x => x.Id == entry.Entity.Id);
         user2.Name.ShouldBe(name2);
         user2.Username.ShouldBe(username2);
    }
}
