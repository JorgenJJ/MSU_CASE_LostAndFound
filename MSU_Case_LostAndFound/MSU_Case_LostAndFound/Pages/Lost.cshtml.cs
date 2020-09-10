using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MSU_Case_LostAndFound.Model;

namespace MSU_Case_LostAndFound.Pages
{
    public class LostModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public LostModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Animal Animal { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Animals.AddAsync(Animal);
                await _db.SaveChangesAsync();
                return RedirectToPage("AnimalList");

            }
            else
            {
                return Page();
            }
        }
    }
}
