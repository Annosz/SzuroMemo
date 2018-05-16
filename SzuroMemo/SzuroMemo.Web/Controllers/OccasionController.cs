using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SzuroMemo.Dal.Services;

namespace SzuroMemo.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class OccasionController : Controller
    {
        public OccasionController(OccasionService occasionService)
        {
            OccasionService = occasionService;
        }

        public OccasionService OccasionService { get; }

        [Authorize(Roles = SzuroMemo.Dal.Users.Roles.Administrators)]
        public IActionResult Delete(int occasionId)
        {
            OccasionService.RemoveOccasion(occasionId);
            return RedirectToPage("/Occasions");
        }
    }
}