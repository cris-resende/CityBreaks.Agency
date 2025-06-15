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
    public class DetailsModel : PageModel
    {
        private readonly CityBreaks.Agency.Data.CityBreakAgencyContext _context;

        public DetailsModel(CityBreaks.Agency.Data.CityBreakAgencyContext context)
        {
            _context = context;
        }

        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteturistico = await _context.PacotesTuristicos
                                               .Include(p => p.Destinos)
                                                   .ThenInclude(d => d.Pais)
                                               .Where(p => p.DeletedAt == null)
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
    }
}