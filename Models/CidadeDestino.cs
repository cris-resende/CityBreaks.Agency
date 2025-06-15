using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Agency.Models
{
    public class CidadeDestino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres.")]
        [Display(Name = "Nome da Cidade")]
        public string Nome { get; set; } = string.Empty;

        public int PaisDestinoId { get; set; }

        public PaisDestino Pais { get; set; } = default!;
        public List<PacoteTuristico> PacotesTuristicos { get; set; } = new List<PacoteTuristico>();
    }
}
