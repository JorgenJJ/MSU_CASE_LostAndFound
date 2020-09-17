using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MSU_Case_LostAndFound.Areas.Identity.Data;
using MSU_Case_LostAndFound.Model;


namespace MSU_Case_LostAndFound.Pages
{
    public class MyAnimalsModel : PageModel
    {
        public IEnumerable<AnimalsLost> AnimalLst { get; set; }

        //public string CurrentFilter { get; set; }

        public readonly string test = "hei";
        private readonly RescuteDBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public MyAnimalsModel(RescuteDBContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;

        }

        [BindProperty]
        public AnimalsLost AnimalsLost { get; set; }
        public async Task OnGetAsync(string searchString, string searchAnimal)
        {

            //CurrentFilter = searchString;

            IQueryable<AnimalsLost> animals = from s in _db.AnimalsLost
                                                 select s;

            string userid = _userManager.GetUserId(HttpContext.User);
            animals = animals.Where(s => s.UserId == userid);
            


            AnimalLst = await animals.AsNoTracking().ToListAsync();

        }




        //public async Task<IActionResult> OnPost()
        //{

        //if (ModelState.IsValid)
        //{
        //    await _db.AnimalsLost.AddAsync(AnimalsLost);
        //    await _db.SaveChangesAsync();
        //    return RedirectToPage("Lost");

        //}
        //else
        //{
        //    return Page();
        //}
        //}
    }
}
