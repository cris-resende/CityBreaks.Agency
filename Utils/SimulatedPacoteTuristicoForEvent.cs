namespace CityBreaks.Agency.Utils
{
    public class SimulatedPacoteTuristicoForEvent
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public int CapacidadeMaxima { get; set; }
        public decimal Preco { get; set; }

        public List<ReservaForEvent> Reservas { get; set; } = new List<ReservaForEvent>();

        public event EventHandler<CapacityReachedEventArgs>? CapacityReached;

        public void AdicionarReserva(ReservaForEvent reserva)
        {
            Reservas.Add(reserva);

            if (Reservas.Count > CapacidadeMaxima)
            {
                OnCapacityReached(new CapacityReachedEventArgs(Id, Titulo, CapacidadeMaxima, Reservas.Count));
            }
        }

        protected virtual void OnCapacityReached(CapacityReachedEventArgs e)
        {
            CapacityReached?.Invoke(this, e);
        }
    }

    public class CapacityReachedEventArgs : EventArgs
    {
        public int PacoteId { get; }
        public string PacoteTitulo { get; }
        public int CapacidadeMaxima { get; }
        public int ReservasAtuais { get; }

        public CapacityReachedEventArgs(int pacoteId, string pacoteTitulo, int capacidadeMaxima, int reservasAtuais)
        {
            PacoteId = pacoteId;
            PacoteTitulo = pacoteTitulo;
            CapacidadeMaxima = capacidadeMaxima;
            ReservasAtuais = reservasAtuais;
        }
    }

    public class ReservaForEvent
    {
        public int Id { get; set; }
        public int PacoteTuristicoId { get; set; }
        public DateTime DataReserva { get; set; }
    }
}
