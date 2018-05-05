using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzuroMemo.Dal.Dtos;

namespace SzuroMemo.Web.ViewComponents
{
    public class OccasionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(OccasionDto occasion)
        {
            return View(occasion);
        }
    }
}
