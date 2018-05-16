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

namespace SzuroMemo.Web.Pages.Account.Personal
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        public DetailsModel(MedicalRecordService medicalRecordService, UserManager<User> userManager)
        {
            MedicalRecordService = medicalRecordService;
            UserManager = userManager;
        }

        public MedicalRecordService MedicalRecordService { get; }
        public UserManager<User> UserManager { get; }

        private int? currentUserId;
        public int? CurrentUserId => User.Identity.IsAuthenticated ? (currentUserId ?? (currentUserId = int.Parse(UserManager.GetUserId(User)))) : null;


        //For Demo
        public string StringData = "";
        public bool BoolData = false;



        [BindProperty]
        public MedicalRecordDto MedicalRecord { get; set; }
        
        public async Task OnGetAsync()
        {
            MedicalRecord = MedicalRecordService.GetMedicalRecordToUser(CurrentUserId.Value);

            if (MedicalRecord == null)
                MedicalRecord = new MedicalRecordDto();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                MedicalRecordService.PutMedicalRecordToUser(CurrentUserId.Value, MedicalRecord);
                return Page();
            }
            return Page();
        }
    }
}