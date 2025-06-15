using CityBreaks.Agency.Models;
using CityBreaks.Agency.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Agency.Pages
{
    public class ClienteDetailsModel : PageModel
    {
        public Cliente? Cliente { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id == 0)
            {
                return RedirectToPage("/Index");
            }

            Cliente = ClientRepositoryForDemo.GetById(id);

            if (Cliente == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
