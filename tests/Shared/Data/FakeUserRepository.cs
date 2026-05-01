using System;
using Seagull.Data;
using Seagull.Data.EntityFrameworkCore;

namespace Tests.Shared.Data;

public interface IFakeUserRepository : IRepository<FakeUser>{}

public class FakeUserRepository : Repository<FakeUser, FakeDbContext>, IFakeUserRepository
{
    public FakeUserRepository(FakeDbContext dbContext) : base(dbContext)
    {
    }
}
