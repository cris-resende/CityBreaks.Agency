using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Agency.Models
{
    public class PaisDestino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O código do país é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O código deve ter 2 caracteres (Ex: BR, US).")]
        [Display(Name = "Código do País")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome do país é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        [Display(Name = "Nome do País")]
        public string Nome { get; set; } = string.Empty;
        public List<CidadeDestino> Cidades { get; set; } = new List<CidadeDestino>();
    }
}
