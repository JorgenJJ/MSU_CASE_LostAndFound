using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MSU_Case_LostAndFound.Model
{
    public class AnimalListModel : PageModel
    {
        public IEnumerable<Animal> AnimalLst { get; set; }

        
        private readonly ApplicationDbContext _db;
        public AnimalListModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            AnimalLst = await _db.Animals.ToListAsync();
        }
    }
}
