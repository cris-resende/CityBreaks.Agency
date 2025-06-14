namespace CityBreaks.Agency.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public int CapacidadeMaxima { get; set; }
        public decimal Preco { get; set; }

        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public event EventHandler<CapacityReachedEventArgs>? CapacityReached;

        public void AdicionarReserva(Reserva reserva)
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
}
