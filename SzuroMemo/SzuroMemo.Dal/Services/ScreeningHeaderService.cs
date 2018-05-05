using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SzuroMemo.Dal.Dtos;

namespace SzuroMemo.Dal.Services
{
    public class ScreeningHeaderService
    {
        public ScreeningHeaderService(SzuroMemoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SzuroMemoDbContext DbContext { get; }

        public IEnumerable<ScreeningHeaderDto> GetScreeningHeaders() => DbContext.Screening
            .Select(s => new ScreeningHeaderDto
            {
                Id = s.Id,
                Name = s.Name
            })
            .OrderBy(s => s.Name);
    }
}
