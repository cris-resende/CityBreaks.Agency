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
    public class IndexModel : PageModel
    {
        private readonly CityBreaks.Agency.Data.CityBreakAgencyContext _context;

        public IndexModel(CityBreaks.Agency.Data.CityBreakAgencyContext context)
        {
            _context = context;
        }

        public IList<PacoteTuristico> PacoteTuristico { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PacotesTuristicos != null)
            {
                PacoteTuristico = await _context.PacotesTuristicos
                                               .Include(p => p.Destinos)
                                               .ToListAsync();
            }
        }
    }
}
