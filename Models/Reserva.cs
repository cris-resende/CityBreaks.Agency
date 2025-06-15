using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Agency.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Display(Name = "Data da Reserva")]
        public DateTime DataReserva { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = default!;

        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; } = default!;
    }
}
