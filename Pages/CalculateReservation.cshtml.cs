using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Agency.Pages
{
    public class CalculateReservationModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "O n�mero de di�rias � obrigat�rio.")]
        [Range(1, 365, ErrorMessage = "O n�mero de di�rias deve ser entre 1 e 365.")]
        [Display(Name = "N�mero de Di�rias")]
        public int NumberOfNights { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "O valor da di�ria � obrigat�rio.")]
        [Range(1, 10000, ErrorMessage = "O valor da di�ria deve ser entre 1 e 10000.")]
        [Display(Name = "Valor da Di�ria (R$)")]
        public int DailyRateInt { get; set; }

        public decimal TotalReservationValue { get; set; }

        private Func<int, int, decimal> _calculateTotal;

        public CalculateReservationModel()
        {
            _calculateTotal = (nights, dailyRate) => (decimal)nights * dailyRate;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            TotalReservationValue = _calculateTotal(NumberOfNights, DailyRateInt);
        }
    }
}
