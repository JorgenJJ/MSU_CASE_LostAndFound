using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MSU_Case_LostAndFound.Areas.Identity.Data;
using MSU_Case_LostAndFound.Model;

namespace MSU_Case_LostAndFound.Pages
{
    public class AnimalProfileModel : PageModel
    {
        public AnimalsLost animal;
        public ApplicationUser user;

        public string userName;
        public string userPhoneNumber;

        private readonly RescuteDBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnimalProfileModel(RescuteDBContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;

        }


        [BindProperty]
        public Animal Animal { get; set; }
        
        public async Task OnGet()
        {
            var temp_id = RouteData.Values["id"];
            animal = await _db.AnimalsLost.FindAsync(int.Parse((string)temp_id));

            var user = await _userManager.FindByIdAsync(animal.UserId);

            userName = user.firstname + " " + user.lastname;
            userPhoneNumber = user.PhoneNumber;

        }
    }
}
