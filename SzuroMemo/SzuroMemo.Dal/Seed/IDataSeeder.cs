using Microsoft.EntityFrameworkCore;
using System;

namespace SzuroMemo.Dal.Seed
{
    public interface IDataSeeder<TDbContext, TData> where TDbContext : DbContext
    {
        int SeedData(TDbContext context, Func<TData> dataAccessor);
    }
}

