using Microsoft.AspNetCore.Mvc;
using SzuroMemo.Dal.Dtos;

namespace SzuroMemo.Web.ViewComponents
{
    public class OccasionListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PagedResult<OccasionDto> occasions)
        {
            return View(occasions);
        }
    }
}
