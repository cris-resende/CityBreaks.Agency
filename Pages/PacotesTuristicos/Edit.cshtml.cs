using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CityBreaks.Agency.Data;
using CityBreaks.Agency.Models;

namespace CityBreaks.Agency.Pages.PacotesTuristicos
{
    public class EditModel : PageModel
    {
        private readonly CityBreaks.Agency.Data.CityBreakAgencyContext _context;

        public EditModel(CityBreaks.Agency.Data.CityBreakAgencyContext context)
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
                                               .Include(p => p.Destinos)
                                                   .ThenInclude(d => d.Pais)
                                               .FirstOrDefaultAsync(m => m.Id == id);

            if (pacoteturistico == null)
            {
                return NotFound();
            }
            PacoteTuristico = pacoteturistico;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                PacoteTuristico = await _context.PacotesTuristicos
                                               .Include(p => p.Destinos)
                                                   .ThenInclude(d => d.Pais)
                                               .FirstOrDefaultAsync(m => m.Id == id);
                return Page();
            }

            var pacoteToUpdate = await _context.PacotesTuristicos.FindAsync(id);

            if (pacoteToUpdate == null)
            {
                return NotFound();
            }

            pacoteToUpdate.Titulo = PacoteTuristico.Titulo;
            pacoteToUpdate.DataInicio = PacoteTuristico.DataInicio;
            pacoteToUpdate.CapacidadeMaxima = PacoteTuristico.CapacidadeMaxima;
            pacoteToUpdate.Preco = PacoteTuristico.Preco;

            try
            {
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Pacote Turístico atualizado com sucesso!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacoteTuristicoExists(pacoteToUpdate.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao salvar o pacote. Tente novamente.");
                PacoteTuristico = await _context.PacotesTuristicos
                                               .Include(p => p.Destinos)
                                                   .ThenInclude(d => d.Pais)
                                               .FirstOrDefaultAsync(m => m.Id == id);
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private bool PacoteTuristicoExists(int id)
        {
            return _context.PacotesTuristicos.Any(e => e.Id == id);
        }
    }
}