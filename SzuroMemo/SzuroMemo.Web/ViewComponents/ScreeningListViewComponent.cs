using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzuroMemo.Dal.Dtos;
using SzuroMemo.Dal.Services;

namespace SzuroMemo.Web.ViewComponents
{
    public class ScreeningListViewComponent : ViewComponent
    {
        public ScreeningListViewComponent(ScreeningHeaderService screeningHeaderService)
        {
            ScreeningHeaderService = screeningHeaderService;
        }

        public ScreeningHeaderService ScreeningHeaderService { get; }

        public IViewComponentResult Invoke()
        {
            return View(ScreeningHeaderService.GetScreeningHeaders());
        }
    }
}
