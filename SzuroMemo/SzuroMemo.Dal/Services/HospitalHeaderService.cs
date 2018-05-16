using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SzuroMemo.Dal.Dtos;

namespace SzuroMemo.Dal.Services
{
    public class HospitalHeaderService
    {
        public HospitalHeaderService(SzuroMemoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SzuroMemoDbContext DbContext { get; }

        public IEnumerable<HospitalHeaderDto> GetHospitalHeaders() => DbContext.Hospital
            .Select(h => new HospitalHeaderDto
            {
                Id = h.Id,
                Name = h.Name
            })
            .OrderBy(s => s.Name);
    }
}
