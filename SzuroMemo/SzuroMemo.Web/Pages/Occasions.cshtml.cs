using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SzuroMemo.Dal.Dtos;
using SzuroMemo.Dal.Services;
using SzuroMemo.Dal.Specifications;

namespace SzuroMemo.Web.Pages
{
    public class OccasionsModel : PageModel
    {
        public OccasionsModel(OccasionService occasionService)
        {
            OccasionService = occasionService;
        }

        public OccasionService OccasionService { get; }

        public PagedResult<OccasionDto> Occasions { get; private set; }

        public void OnGet(OccasionSpecification Specification)
        {
            if (Specification == null)
                Specification = new OccasionSpecification();
            if (Specification.PageNumber != null)
                Specification.PageNumber -= 1;
            if (Specification.PageSize == null)
                Specification.PageSize = 2;

            Occasions = OccasionService.GetOccasions(Specification);
        }
    }
}