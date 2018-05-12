using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using SzuroMemo.Dal.Dtos;
using SzuroMemo.Dal.Entities;
using SzuroMemo.Dal.Services;

namespace SzuroMemo.Web.ViewComponents
{
    public class OccasionViewComponent : ViewComponent
    {
        #region Constructor

        public OccasionViewComponent(RegistrationService registrationService, UserManager<User> userManager)
        {
            RegistrationService = registrationService;
            UserManager = userManager;
        }

        #endregion


        #region Properties

        public RegistrationService RegistrationService { get; }
        public UserManager<User> UserManager { get; }

        private int? currentUserId;
        public int? CurrentUserId => User.Identity.IsAuthenticated ? (currentUserId ?? (currentUserId = int.Parse(UserManager.GetUserId(new ClaimsPrincipal(User))))) : null;

        #endregion


        #region ViewComponent

        public IViewComponentResult Invoke(OccasionDto occasion)
        {
            if (CurrentUserId == null || UserNotRegistered(occasion))
                return View(occasion);
            else
                return View("Registered", occasion);
        }

        #endregion

        #region Helpers

        private bool UserNotRegistered(OccasionDto occasion)
        {
            return RegistrationService.GetRegistratiosnToUser(CurrentUserId.Value).FirstOrDefault(r => r.OccasionId == occasion.Id) == null;
        }

        #endregion
    }
}
