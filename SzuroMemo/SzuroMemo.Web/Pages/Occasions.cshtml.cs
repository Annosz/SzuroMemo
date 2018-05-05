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
    public class OccasionsModel : PageModel
    {
        public IEnumerable<OccasionDto> Occasions { get; private set; }

        public void OnGet([FromServices]OccasionService occasionService)
        {
            Occasions = occasionService.GetOccasions();
        }
    }
}