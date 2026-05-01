using System;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;

namespace Tests.Shared.Data;

public interface IFakeBookRepository : IRepository<FakeBook>
{
}

public class FakeBookRepository : Repository<FakeBook, FakeDbContext>, IFakeBookRepository
{
    public FakeBookRepository(FakeDbContext dbContext) : base(dbContext)
    {
    }
}
