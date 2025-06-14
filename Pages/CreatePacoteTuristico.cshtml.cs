using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Agency.Pages
{
    public class CreatePacoteTuristicoModel : PageModel
    {
        [BindProperty]
        public InputModel PacoteInput { get; set; } = new InputModel();

        public class InputModel
        {
            [Required(ErrorMessage = "O t�tulo do pacote � obrigat�rio.")]
            [StringLength(150, MinimumLength = 5, ErrorMessage = "O t�tulo deve ter entre 5 e 150 caracteres.")]
            [Display(Name = "T�tulo do Pacote")]
            public string Titulo { get; set; } = string.Empty;

            [Required(ErrorMessage = "A data de in�cio � obrigat�ria.")]
            [DataType(DataType.Date, ErrorMessage = "Formato de data inv�lido.")]
            [Display(Name = "Data de In�cio")]
            public DateTime DataInicio { get; set; }

            [Required(ErrorMessage = "A capacidade m�xima � obrigat�ria.")]
            [Range(1, 1000, ErrorMessage = "A capacidade deve ser entre 1 e 1000 participantes.")]
            [Display(Name = "Capacidade M�xima")]
            public int CapacidadeMaxima { get; set; }

            [Required(ErrorMessage = "O pre�o � obrigat�rio.")]
            [Range(0.01, 100000.00, ErrorMessage = "O pre�o deve ser entre 0.01 e 100000.00.")]
            [DataType(DataType.Currency, ErrorMessage = "Formato de moeda inv�lido.")]
            [Display(Name = "Pre�o (R$)")]
            public decimal Preco { get; set; }
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Console.WriteLine($"[CADASTRO SUCESSO] Pacote Tur�stico '{PacoteInput.Titulo}' com pre�o R$ {PacoteInput.Preco:F2} e capacidade {PacoteInput.CapacidadeMaxima} cadastrado (simulado).");

            TempData["SuccessMessage"] = $"Pacote '{PacoteInput.Titulo}' cadastrado com sucesso (simulado)!";
            return RedirectToPage("/Index");
        }
    }
}
