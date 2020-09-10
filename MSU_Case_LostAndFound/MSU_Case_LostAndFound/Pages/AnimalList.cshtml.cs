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
