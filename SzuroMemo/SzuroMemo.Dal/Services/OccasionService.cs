using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SzuroMemo.Dal.Dtos;
using SzuroMemo.Dal.Entities;
using SzuroMemo.Dal.Specifications;

namespace SzuroMemo.Dal.Services
{
    public class OccasionService
    {
        public OccasionService(SzuroMemoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SzuroMemoDbContext DbContext { get; }

        public PagedResult<OccasionDto> GetOccasions(OccasionSpecification specification = null)
        {

            //Missing values
            if (specification == null)
                specification = new OccasionSpecification();

            if (specification?.PageSize < 0)
                specification.PageSize = null;
            if (specification?.PageNumber < 0)
                specification.PageNumber = null;


            //Query
            IQueryable<Occasion> query = DbContext.Occasion
                .Include(o => o.Hospital)
                .Include(o => o.Hospital.Address)
                .Include(o => o.Screening)
                .Include(o => o.Registrations);


            //Filtering
            if (!string.IsNullOrWhiteSpace(specification.Screening))
                query = query.Where(o => o.Screening.Name.Contains(specification.Screening));
            if (specification.ScreeningId != null)
                query = query.Where(o => o.ScreeningId == specification.ScreeningId);
            if (!string.IsNullOrWhiteSpace(specification.Hospital))
                query = query.Where(o => o.Hospital.Name.Contains(specification.Hospital));
            if (specification.HospitalId != null)
                query = query.Where(o => o.HospitalId == specification.HospitalId);
            if (!string.IsNullOrWhiteSpace(specification.Settlement))
                query = query.Where(o => o.Hospital.Address.Settlement.Contains(specification.Settlement));
            if (specification.MinStart != null)
                query = query.Where(o => o.StartTime >= specification.MinStart);
            if (specification.MaxEnd != null)
                query = query.Where(o => o.EndTime <= specification.MaxEnd);
            if (specification.ReferralNotNeeded == true)
                query = query.Where(o => !o.Screening.ReferralNeeded);
            if (specification.HasDescription == true)
                query = query.Where(o => !String.IsNullOrEmpty(o.Description));


            //Ordering
            switch (specification.Order)
            {
                case OccasionSpecification.ScreeningOrder.StartAscending:
                    query = query.OrderBy(o => o.StartTime);
                    break;
                case OccasionSpecification.ScreeningOrder.HospitalAscending:
                    query = query.OrderBy(o => o.Hospital.Name);
                    break;
                case OccasionSpecification.ScreeningOrder.HospitalDescending:
                    query = query.OrderByDescending(o => o.Hospital.Name);
                    break;
                case OccasionSpecification.ScreeningOrder.ScreeningAscending:
                    query = query.OrderBy(o => o.Screening);
                    break;
                case OccasionSpecification.ScreeningOrder.ScreeningDescending:
                    query = query.OrderByDescending(o => o.Screening);
                    break;
                case OccasionSpecification.ScreeningOrder.RegistrationNumAscending:
                    query = query.OrderBy(o => o.Registrations.Count);
                    break;
                case OccasionSpecification.ScreeningOrder.RegistrationNumDescending:
                    query = query.OrderByDescending(o => o.Registrations.Count);
                    break;
                case OccasionSpecification.ScreeningOrder.SettlementAscending:
                    query = query.OrderBy(o => o.Hospital.Address.Settlement);
                    break;
                case OccasionSpecification.ScreeningOrder.SettlementDescending:
                    query = query.OrderByDescending(o => o.Hospital.Address.Settlement);
                    break;
                default:
                    break;
            }


            //Paging
            int? allResultsCount = null;
            if (((specification.PageSize) ?? 0) != 0)
            {
                specification.PageNumber = specification.PageNumber ?? 0;
                allResultsCount = query.Count();
                query = query.Skip(specification.PageNumber.Value * specification.PageSize.Value)
                    .Take(specification.PageSize.Value);
            }


            //Result
            return new PagedResult<OccasionDto>
            {
                AllResultsCount = allResultsCount,
                PageNumber = specification.PageNumber,
                PageSize = specification.PageSize,
                Results = query.ToList()
                    .Select(o => new OccasionDto
                    {
                        Id = o.Id,
                        StartTime = o.StartTime,
                        EndTime = o.EndTime,
                        Description = o.Description,

                        ScreeningId = o.Screening.Id,
                        Screening = o.Screening.Name,
                        ReferralNeeded = o.Screening.ReferralNeeded,

                        HospitalId = o.Hospital.Id,
                        Hospital = o.Hospital.Name,
                        Address = o.Hospital.Address,
                        PictureUrl = o.Hospital.PictureUrl,

                        RegistrationNum = o.Registrations.Count
                    })

            };

        }


        public OccasionDto GetOccasion(int occasionId)
        {
            //Query
            IQueryable<Occasion> query = DbContext.Occasion.Where(o => o.Id == occasionId)
                .Include(o => o.Hospital)
                .Include(o => o.Hospital.Address)
                .Include(o => o.Screening)
                .Include(o => o.Registrations);

            return query.Select(o => new OccasionDto
            {
                Id = o.Id,
                StartTime = o.StartTime,
                EndTime = o.EndTime,
                Description = o.Description,

                ScreeningId = o.Screening.Id,
                Screening = o.Screening.Name,
                ReferralNeeded = o.Screening.ReferralNeeded,

                HospitalId = o.Hospital.Id,
                Hospital = o.Hospital.Name,
                Address = o.Hospital.Address,
                PictureUrl = o.Hospital.PictureUrl,

                RegistrationNum = o.Registrations.Count
            }).First();
        }


        public OccasionDto AddOccasion(OccasionDto occasion)
        {
            DbContext.Add(new Occasion
            {
                StartTime = occasion.StartTime,
                EndTime = occasion.EndTime,
                Description = occasion.Description,

                ScreeningId = occasion.ScreeningId,

                HospitalId = occasion.HospitalId
            });

            DbContext.SaveChanges();

            return occasion;
        }

        public OccasionDto RemoveOccasion(int occasionId)
        {
            Occasion occasion = DbContext.Occasion
                .Include(o => o.Hospital)
                .Include(o => o.Hospital.Address)
                .Include(o => o.Screening)
                .Include(o => o.Registrations)
                .FirstOrDefault(o => o.Id == occasionId);

            DbContext.Occasion.Remove(occasion);

            DbContext.SaveChanges();

            return new OccasionDto
            {
                Id = occasion.Id,
                StartTime = occasion.StartTime,
                EndTime = occasion.EndTime,
                Description = occasion.Description,

                ScreeningId = occasion.Screening.Id,
                Screening = occasion.Screening.Name,
                ReferralNeeded = occasion.Screening.ReferralNeeded,

                HospitalId = occasion.Hospital.Id,
                Hospital = occasion.Hospital.Name,
                Address = occasion.Hospital.Address,
                PictureUrl = occasion.Hospital.PictureUrl,

                RegistrationNum = occasion.Registrations.Count
            };
        }
    }
}
