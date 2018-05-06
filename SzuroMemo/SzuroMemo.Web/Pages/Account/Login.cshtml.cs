using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SzuroMemo.Dal.Entities;

namespace SzuroMemo.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        #region Constructor

        public LoginModel(SignInManager<User> signInManager)
        {
            SignInManager = signInManager;
        }

        #endregion

        #region Properties

        public class InputModel
        {
            [Required(ErrorMessage = "A felhasználónév megadása kötelező"), Display(Name = "Felhasználónév")]
            public string UserName { get; set; }
            [Required(ErrorMessage = "A jelszó megadása kötelező"), DataType(DataType.Password), Display(Name = "Jelszó")]
            public string Password { get; set; }
            [Display(Name = "Maradjak belépve")]
            public bool KeepMeSignedIn { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }
        
        private SignInManager<User> SignInManager { get; }

        #endregion

        public ActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToPage("/Index");
            return Page();
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var signInResult = SignInManager
                    .PasswordSignInAsync(Input.UserName, Input.Password, Input.KeepMeSignedIn, false)
                    .GetAwaiter().GetResult();
                if (!signInResult.Succeeded)
                    ModelState.AddModelError("", "Sikertelen bejelentkezési kísérlet.");
                else
                    return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}