using CityBreaks.Agency.Models;
using CityBreaks.Agency.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Agency.Pages
{
    public class CreateClienteModel : PageModel
    {
        [BindProperty]
        public Cliente Cliente { get; set; } = new Cliente();

        public void OnGet(){}

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ClientRepositoryForDemo.Add(Cliente);
            Console.WriteLine($"[CADASTRO SUCESSO] Cliente '{Cliente.Nome}' com e-mail '{Cliente.Email}' cadastrado (ID: {Cliente.Id}).");

            TempData["SuccessMessage"] = $"Cliente '{Cliente.Nome}' cadastrado com sucesso (ID: {Cliente.Id})!";
            return RedirectToPage("/Index");
        }
    }
}
