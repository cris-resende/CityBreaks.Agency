using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CityBreaks.Agency.Data;
using CityBreaks.Agency.Models;

namespace CityBreaks.Agency.Pages.PacotesTuristicos
{
    public class DeleteModel : PageModel
    {
        private readonly CityBreaks.Agency.Data.CityBreakAgencyContext _context;

        public DeleteModel(CityBreaks.Agency.Data.CityBreakAgencyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteturistico = await _context.PacotesTuristicos
                                               .Where(m => m.DeletedAt == null)
                                               .FirstOrDefaultAsync(m => m.Id == id);

            if (pacoteturistico == null)
            {
                return NotFound();
            }
            else
            {
                PacoteTuristico = pacoteturistico;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteturistico = await _context.PacotesTuristicos.FindAsync(id);
            if (pacoteturistico != null)
            {
                pacoteturistico.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Pacote Turístico deletado (soft delete) com sucesso!";
            }

            return RedirectToPage("./Index");
        }
    }
}