using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SzuroMemo.Dal;
using SzuroMemo.Dal.Entities;

namespace SzuroMemo.Web.Pages
{
    public class OccasionsModel : PageModel
    {
        public IEnumerable<Occasion> Occasions { get; private set; }

        public void OnGet([FromServices]SzuroMemoDbContext ctx)
        {
            Occasions = ctx.Occasion;
        }
    }
}