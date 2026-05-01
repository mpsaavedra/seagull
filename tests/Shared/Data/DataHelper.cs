using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Shared.Data;

public static class DataHelper
{
    public static IServiceProvider InitializeDataNotPopulated(string section) =>
        new ServiceCollection()
            .AddDbContext<FakeDbContext>(cfg => cfg.UseInMemoryDatabase($"test_{section}_InMemoryDb"))
            .AddScoped<IFakeBookRepository, FakeBookRepository>()
            .AddScoped<IFakeCategoryRepository, FakeCategoryRepository>()
            .AddScoped<IFakeUserRepository, FakeUserRepository>()
            .BuildServiceProvider();

    public static IServiceProvider InitializeDataPopulated(string section, int amountUsers = -1)
    {
        var provider = InitializeDataNotPopulated(section);
        var ctx = provider.GetRequiredService<FakeDbContext>();
        PopulateUsers(ctx, amountUsers);
        PopulateLibrary(ctx);
        return provider;   
    }

    public static void PopulateUsers(FakeDbContext ctx, int amount)
    {
        var all = amount == -1;
        amount = all ? Helpers.Names().Count() - 1 : amount;
        for(var i = 0; i < amount; i++)
        {
            var name = all ? Helpers.Names()[i] :  Helpers.RandomName();
            ctx.Users.Add(new FakeUser{ Name =  name, Username = name });
        }
        ctx.SaveChanges();
    }

    public static void PopulateLibrary(FakeDbContext ctx)
    {
        var cat1 = new FakeCategory { Name = "Fiction" };
        var cat2 = new FakeCategory { Name = "Child" };

        var book1 = new FakeBook  { Title = "Lord of the rings I",  Category = cat1 };
        var book2 = new FakeBook  { Title = "Moby Dick",            Category = cat1 };
        var book3 = new FakeBook  { Title = "Alien",                Category = cat1 };
        var book4 = new FakeBook  { Title = "The Capital",          Category = cat1 };
        var book5 = new FakeBook  { Title = "Theorical Socialism",  Category = cat1 };
        var book6 = new FakeBook  { Title = "What Alejandro knows", Category = cat2 };
        var book7 = new FakeBook  { Title = "Mother goose stories", Category = cat2 };
        var book8 = new FakeBook  { Title = "The Book of Dwarfs",   Category = cat2 };
        var book9 = new FakeBook  { Title = "The golden age",       Category = cat2 };
        var book10 = new FakeBook { Title = "Tic-Tac-Toe",          Category = cat2 };

        ctx.Categories.AddRange(cat1, cat2);
        ctx.Books.AddRange(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10);

        ctx.SaveChanges();
    }
}
