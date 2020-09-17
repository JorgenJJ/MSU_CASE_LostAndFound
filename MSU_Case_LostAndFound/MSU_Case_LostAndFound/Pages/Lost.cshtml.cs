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
        //public string CurrentFilter { get; set; }


        private readonly RescuteDBContext _db;
        public LostModel(RescuteDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AnimalsLost AnimalsLost { get; set; }
        public async Task OnGetAsync(string searchString, string searchAnimal)
        {

            //CurrentFilter = searchString;

            IQueryable<AnimalsLost> animals = from s in _db.AnimalsLost
                                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                animals = animals.Where(s => s.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(searchAnimal))
            {
                //AnimalsLost.AnimalId myValueAsEnum = (AnimalsLost.Animal)
                //              Enum.Parse(typeof(AnimalsLost.Animal), searchAnimal);

                animals = animals.Where(s => s.Animal == (Animal)Enum.Parse(typeof(Animal), searchAnimal));
            }

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
