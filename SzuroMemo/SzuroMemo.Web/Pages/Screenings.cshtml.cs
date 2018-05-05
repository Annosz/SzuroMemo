using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SzuroMemo.Dal;
using SzuroMemo.Dal.Dtos;
using SzuroMemo.Dal.Entities;
using SzuroMemo.Dal.Services;

namespace SzuroMemo.Web.Pages
{
    public class ScreeningsModel : PageModel
    {
        public IEnumerable<ScreeningDto> Screenings { get; private set; }

        public void OnGet([FromServices]ScreeningService screeningService)
        {
            Screenings = screeningService.GetScreenings();
        }
    }
}
