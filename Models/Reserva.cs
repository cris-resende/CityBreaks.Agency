namespace CityBreaks.Agency.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int PacoteTuristicoId { get; set; }
        public DateTime DataReserva { get; set; }

    }
}
