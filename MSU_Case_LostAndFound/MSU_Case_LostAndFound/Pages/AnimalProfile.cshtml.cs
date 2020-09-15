using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MSU_Case_LostAndFound.Model;

namespace MSU_Case_LostAndFound.Pages
{
    public class AnimalProfileModel : PageModel
    {
        public Animal animal;

        private readonly ApplicationDbContext _db;
        public AnimalProfileModel(ApplicationDbContext db)
        {
            _db = db;
        }


        [BindProperty]
        public Animal Animal { get; set; }

        public async Task OnGet()
        {
            var temp_id = RouteData.Values["id"];
            animal = await _db.Animals.FindAsync(int.Parse((string)temp_id));
        }
    }
}
