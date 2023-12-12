using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Personal_Website.Data;
using Personal_Website.Models;

namespace Personal_Website.Pages.Videogames
{
    public class DeleteModel : PageModel
    {
        private readonly Personal_Website.Data.Personal_WebsiteContext _context;

        public DeleteModel(Personal_Website.Data.Personal_WebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Videogame Videogame { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videogame = await _context.Videogames.FirstOrDefaultAsync(m => m.Id == id);

            if (videogame == null)
            {
                return NotFound();
            }
            else
            {
                Videogame = videogame;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videogame = await _context.Videogames.FindAsync(id);
            if (videogame != null)
            {
                Videogame = videogame;
                _context.Videogames.Remove(Videogame);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
