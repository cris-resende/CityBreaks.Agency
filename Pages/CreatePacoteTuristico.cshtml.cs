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
            [Required(ErrorMessage = "O título do pacote é obrigatório.")]
            [StringLength(150, MinimumLength = 5, ErrorMessage = "O título deve ter entre 5 e 150 caracteres.")]
            [Display(Name = "Título do Pacote")]
            public string Titulo { get; set; } = string.Empty;

            [Required(ErrorMessage = "A data de início é obrigatória.")]
            [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]
            [Display(Name = "Data de Início")]
            public DateTime DataInicio { get; set; }

            [Required(ErrorMessage = "A capacidade máxima é obrigatória.")]
            [Range(1, 1000, ErrorMessage = "A capacidade deve ser entre 1 e 1000 participantes.")]
            [Display(Name = "Capacidade Máxima")]
            public int CapacidadeMaxima { get; set; }

            [Required(ErrorMessage = "O preço é obrigatório.")]
            [Range(0.01, 100000.00, ErrorMessage = "O preço deve ser entre 0.01 e 100000.00.")]
            [DataType(DataType.Currency, ErrorMessage = "Formato de moeda inválido.")]
            [Display(Name = "Preço (R$)")]
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

            Console.WriteLine($"[CADASTRO SUCESSO] Pacote Turístico '{PacoteInput.Titulo}' com preço R$ {PacoteInput.Preco:F2} e capacidade {PacoteInput.CapacidadeMaxima} cadastrado (simulado).");

            TempData["SuccessMessage"] = $"Pacote '{PacoteInput.Titulo}' cadastrado com sucesso (simulado)!";
            return RedirectToPage("/Index");
        }
    }
}
