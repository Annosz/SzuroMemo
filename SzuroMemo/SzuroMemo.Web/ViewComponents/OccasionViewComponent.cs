using Microsoft.AspNetCore.Mvc;
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
