using System;
using Microsoft.EntityFrameworkCore;
using Tests.Shared.Data.Configurations;

namespace Tests.Shared.Data;

public class FakeDbContext : DbContext
{
    public FakeDbContext()
    {
    }
    public FakeDbContext(DbContextOptions<FakeDbContext> opts) : base(opts)
    {
    }

    public DbSet<FakeBook> Books => Set<FakeBook>();
    public DbSet<FakeCategory> Categories => Set<FakeCategory>();
    public DbSet<FakeUser> Users => Set<FakeUser>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FakeBookConfiguration());
        modelBuilder.ApplyConfiguration(new FakeCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new FakeUserConfiguration());
    }
}
