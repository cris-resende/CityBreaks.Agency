using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CityBreaks.Agency.Data;
using CityBreaks.Agency.Models;

namespace CityBreaks.Agency.Pages.PacotesTuristicos
{
    public class CreateModel : PageModel
    {
        private readonly CityBreaks.Agency.Data.CityBreakAgencyContext _context;

        public CreateModel(CityBreaks.Agency.Data.CityBreakAgencyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.PacotesTuristicos.AddAsync(PacoteTuristico);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}