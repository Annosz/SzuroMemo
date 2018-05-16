using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SzuroMemo.Dal.Dtos;
using SzuroMemo.Dal.Services;

namespace SzuroMemo.Web.Pages
{
    public class OccasionModel : PageModel
    {
        public OccasionModel(OccasionService occasionService, ScreeningService screeningService)
        {
            OccasionService = occasionService;
            ScreeningService = screeningService;
        }

        public OccasionService OccasionService { get; }
        public ScreeningService ScreeningService { get; }

        public OccasionDto Occasion { get; set; }

        public void OnGet(int occasionId)
        {
            Occasion = OccasionService.GetOccasion(occasionId);
        }
    }
}