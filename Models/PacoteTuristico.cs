using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Agency.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }

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
}
