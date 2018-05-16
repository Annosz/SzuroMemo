using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SzuroMemo.Dal.Dtos;
using SzuroMemo.Dal.Services;

namespace SzuroMemo.Web.Pages
{
    [Authorize(Roles = SzuroMemo.Dal.Users.Roles.Administrators)]
    public class NewOccasionModel : PageModel
    {
        public NewOccasionModel(OccasionService occasionService, ScreeningHeaderService screeningHeaderService, HospitalHeaderService hospitalHeaderService)
        {
            OccasionService = occasionService;
            ScreeningHeaderService = screeningHeaderService;
            HospitalHeaderService = hospitalHeaderService;
        }

        public OccasionService OccasionService { get; }
        public ScreeningHeaderService ScreeningHeaderService { get; }
        public HospitalHeaderService HospitalHeaderService { get; }

        [BindProperty]
        public OccasionDto Occasion { get; set; }
        public List<SelectListItem> Screenings { get; set; }
        public List<SelectListItem> Hospitals { get; set; }

        public void OnGet()
        {
            Screenings = ScreeningHeaderService.GetScreeningHeaders().Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() }).ToList();
            Hospitals = HospitalHeaderService.GetHospitalHeaders().Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() }).ToList();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                OccasionService.AddOccasion(Occasion);
                return Page();
            }
            return Page();
        }
    }
}