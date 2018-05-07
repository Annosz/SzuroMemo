using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SzuroMemo.Dal.Entities;

namespace SzuroMemo.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        public AccountController(SignInManager<User> signInManager)
        {
            SignInManager = signInManager;
        }

        public SignInManager<User> SignInManager { get; }

        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}