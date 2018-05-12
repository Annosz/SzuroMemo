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

        [BindProperty]
        public OccasionSpecification Specification { get; set; }

        public void OnGet(OccasionSpecification specification)
        {
            if (specification == null)
                specification = new OccasionSpecification();
            else
                Specification = specification;
            if (specification.PageNumber != null)
                specification.PageNumber -= 1;
            if (specification.PageSize == null)
                specification.PageSize = 24;

            Occasions = OccasionService.GetOccasions(specification);
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/Occasions", Specification);
            }
            return Page();
        }
    }
}