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
    public class FoundModel : PageModel
    {
        public IEnumerable<AnimalsFound> AnimalLst { get; set; }
        //public string CurrentFilter { get; set; }


        private readonly RescuteDBContext _db;
        public FoundModel(RescuteDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AnimalsFound AnimalsFound { get; set; }
        public async Task OnGetAsync(string searchString, string searchAnimal)
        {

            //CurrentFilter = searchString;

            IQueryable<AnimalsFound> animals = from s in _db.AnimalsFound
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