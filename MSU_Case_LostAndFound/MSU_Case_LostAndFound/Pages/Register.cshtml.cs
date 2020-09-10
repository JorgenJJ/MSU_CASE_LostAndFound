using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MSU_Case_LostAndFound.Models;

namespace MSU_Case_LostAndFound.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly RescuteDBContext _db;

        public RegisterModel(RescuteDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AnimalsLost AnimalsLost { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.AnimalsLost.AddAsync(AnimalsLost);
                await _db.SaveChangesAsync();
                return RedirectToPage("Lost");

            }
            else
            {
                return Page();
            }
        }
    }
}
