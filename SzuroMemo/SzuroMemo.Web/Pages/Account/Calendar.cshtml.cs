using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SzuroMemo.Dal.Dtos;
using SzuroMemo.Dal.Entities;
using SzuroMemo.Dal.Services;
using SzuroMemo.Dal.Specifications;

namespace SzuroMemo.Web.Pages
{
    [Authorize]
    public class CalendarModel : PageModel
    {
        public CalendarModel(RegistrationService registrationService, UserManager<User> userManager)
        {
            RegistrationService = registrationService;
            UserManager = userManager;
        }

        public RegistrationService RegistrationService { get; }
        public UserManager<User> UserManager { get; }

        private int? currentUserId;
        public int? CurrentUserId => User.Identity.IsAuthenticated ? (currentUserId ?? (currentUserId = int.Parse(UserManager.GetUserId(User)))) : null;

        public PagedResult<OccasionDto> Occasions { get; private set; }

        public void OnGet()
        {
            Occasions = new PagedResult<OccasionDto>
            {
                Results = RegistrationService.GetOccasionsToUser(CurrentUserId.Value)
            };
        }
    }
}