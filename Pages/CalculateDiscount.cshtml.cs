using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static CityBreaks.Agency.Utils.Delegates;

namespace CityBreaks.Agency.Pages
{
    public class CalculateDiscountModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "O pre�o � obrigat�rio.")]
        [Range(0.01, 100000.00, ErrorMessage = "O pre�o deve ser entre 0.01 e 100000.00.")]
        [Display(Name = "Pre�o Original da Di�ria")]
        public decimal OriginalPrice { get; set; }

        public decimal DiscountedPrice { get; set; }

        private CalculateDelegate _calculateDiscount;

        public CalculateDiscountModel()
        {
            _calculateDiscount = DiscountCalculator.ApplyTenPercentDiscount;
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

            DiscountedPrice = _calculateDiscount(OriginalPrice);
        }
    }
}
