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
        public IEnumerable<AnimalsLost> tmpAnimalLst { get; set; }


        private readonly RescuteDBContext _db;
        public AnimalListModel(RescuteDBContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            tmpAnimalLst = await _db.AnimalsLost.ToListAsync();
        }
    }
}
