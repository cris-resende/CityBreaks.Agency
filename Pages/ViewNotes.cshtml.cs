using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Agency.Pages
{
    public class ViewNotesModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ViewNotesModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public InputModel NoteInput { get; set; } = new InputModel();

        public class InputModel
        {
            [Required(ErrorMessage = "O t�tulo da nota � obrigat�rio.")]
            [StringLength(100, MinimumLength = 3, ErrorMessage = "O t�tulo deve ter entre 3 e 100 caracteres.")]
            [Display(Name = "T�tulo da Nota")]
            public string Title { get; set; } = string.Empty;

            [Required(ErrorMessage = "O conte�do da nota � obrigat�rio.")]
            [StringLength(5000, ErrorMessage = "O conte�do n�o pode exceder 5000 caracteres.")]
            [Display(Name = "Conte�do da Nota")]
            public string Content { get; set; } = string.Empty;
        }

        public List<string> AvailableNotes { get; set; } = new List<string>();

        public string? SelectedNoteContent { get; set; }

        public string? SelectedNoteFileName { get; set; }


        public async Task OnGetAsync(string? fileName)
        {
            await LoadAvailableNotes();

            if (!string.IsNullOrEmpty(fileName))
            {
                SelectedNoteFileName = fileName;
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "files", fileName);

                if (System.IO.File.Exists(filePath))
                {
                    SelectedNoteContent = await System.IO.File.ReadAllTextAsync(filePath);
                }
                else
                {
                    SelectedNoteContent = "Nota n�o encontrada.";
                }
            }
        }

        public async Task<IActionResult> OnPostCreateNote()
        {
            if (!ModelState.IsValid)
            {
                await LoadAvailableNotes();
                return Page();
            }

            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "files");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            string fileName = NoteInput.Title.Replace(" ", "_") + ".txt";
            string filePath = Path.Combine(uploadPath, fileName);

            try
            {
                await System.IO.File.WriteAllTextAsync(filePath, NoteInput.Content);
                TempData["SuccessMessage"] = $"Nota '{NoteInput.Title}' salva com sucesso!";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao salvar a nota: {ex.Message}");
                TempData["ErrorMessage"] = $"Erro ao salvar a nota: {ex.Message}";
            }

            NoteInput.Title = string.Empty;
            NoteInput.Content = string.Empty;

            await LoadAvailableNotes();

            return Page();
        }

        private async Task LoadAvailableNotes()
        {
            string filesPath = Path.Combine(_webHostEnvironment.WebRootPath, "files");
            if (Directory.Exists(filesPath))
            {
                AvailableNotes = Directory.GetFiles(filesPath, "*.txt")
                                          .Select(Path.GetFileName)
                                          .ToList();
            }
            else
            {
                AvailableNotes = new List<string>();
            }
        }
    }
}
