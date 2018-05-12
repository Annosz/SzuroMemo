using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SzuroMemo.Dal.Entities;
using SzuroMemo.Dal.Services;

namespace SzuroMemo.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class RegistrationController : Controller
    {
        public RegistrationController(RegistrationService registrationService, UserManager<User> userManager)
        {
            RegistrationService = registrationService;
            UserManager = userManager;
        }

        public RegistrationService RegistrationService { get; }

        public UserManager<User> UserManager { get; }

        private int? currentUserId;
        public int? CurrentUserId => User.Identity.IsAuthenticated ? (currentUserId ?? (currentUserId = int.Parse(UserManager.GetUserId(User)))) : null;

        [HttpPost]
        public IActionResult Register(int occasionId, string origin, string query)
        {
            RegistrationService.RegistrateUserToOccasion(CurrentUserId.Value, occasionId);

            return Redirect(origin + query);
        }

        [HttpPost]
        public IActionResult Unregister(int occasionId, string origin, string query)
        {
            RegistrationService.UnregistrateUserFromOccasion(CurrentUserId.Value, occasionId);

            return Redirect(origin + query);
        }
    }
}