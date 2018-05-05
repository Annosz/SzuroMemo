using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SzuroMemo.Dal.Dtos;

namespace SzuroMemo.Dal.Services
{
    public class ScreeningService
    {
        public ScreeningService(SzuroMemoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SzuroMemoDbContext DbContext { get; }

        public IEnumerable<ScreeningDto> GetScreenings() => DbContext.Screening
            .Include(s => s.Occasions)
            .Select(s => new ScreeningDto
            {
                Id = s.Id,
                Name = s.Name,
                ReferralNeeded = s.ReferralNeeded,
                Description = s.Description,

                OccasionNum = s.Occasions.Count
            })
            .OrderBy(s => s.Name);
    }
}
