using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using CityBreaks.Agency.Utils;

namespace CityBreaks.Agency.Pages
{
    public class LogOperationsModel : PageModel
    {
        private Action<string> _logAction;

        [BindProperty]
        [Required(ErrorMessage = "A mensagem de log é obrigatória.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "A mensagem deve ter entre 5 e 200 caracteres.")]
        [Display(Name = "Mensagem de Operação")]
        public string LogMessage { get; set; } = string.Empty;

        public List<string> MemoryLogsDisplay { get; set; } = new List<string>();

        public LogOperationsModel()
        {
            _logAction = Logger.LogToConsole;
            _logAction += Logger.LogToFile;
            _logAction += Logger.LogToMemory;
        }

        public void OnGet()
        {
            MemoryLogsDisplay = Logger.MemoryLogs;
        }

        public IActionResult OnPostRecordLog()
        {
            if (!ModelState.IsValid)
            {
                MemoryLogsDisplay = Logger.MemoryLogs;
                return Page();
            }

            _logAction($"Operação Registrada: {LogMessage}");

            LogMessage = string.Empty;

            MemoryLogsDisplay = Logger.MemoryLogs;

            return Page();
        }

        public IActionResult OnPostClearMemoryLogs()
        {
            Logger.ClearMemoryLogs();
            MemoryLogsDisplay = Logger.MemoryLogs;
            return Page();
        }
    }
}
