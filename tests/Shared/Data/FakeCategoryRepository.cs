using System;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;

namespace Tests.Shared.Data;

public interface IFakeCategoryRepository : IRepository<FakeCategory>
{
    
}

public class FakeCategoryRepository : Repository<FakeCategory, FakeDbContext>, IFakeCategoryRepository
{
    public FakeCategoryRepository(FakeDbContext dbContext) : base(dbContext)
    {
    }
}
