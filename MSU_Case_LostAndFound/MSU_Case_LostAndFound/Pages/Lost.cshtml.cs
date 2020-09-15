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
        public IEnumerable<AnimalsLost> AnimalLst { get; set; }

        private readonly RescuteDBContext _db;
        public LostModel(RescuteDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AnimalsLost AnimalsLost { get; set; }
        public async Task OnGet()
        {
            AnimalLst = await _db.AnimalsLost.ToListAsync();
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
