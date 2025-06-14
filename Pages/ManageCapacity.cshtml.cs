using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using CityBreaks.Agency.Models;
using System.Collections.Generic;
using System.Linq;
using CityBreaks.Agency.Utils;

namespace CityBreaks.Agency.Pages
{
    public class ManageCapacityModel : PageModel
    {
        private static SimulatedPacoteTuristicoForEvent _staticCurrentPackage = new SimulatedPacoteTuristicoForEvent
        {
            Id = 1,
            Titulo = "Aventura na Amazônia",
            CapacidadeMaxima = 3,
            DataInicio = DateTime.Now.AddMonths(1),
            Preco = 1500.00M
        };

        public SimulatedPacoteTuristicoForEvent CurrentPackage => _staticCurrentPackage;

        private Action<string> _consoleLogger;

        public ManageCapacityModel()
        {
            _consoleLogger = LogToConsole;
            _staticCurrentPackage.CapacityReached -= HandleCapacityReached;
            _staticCurrentPackage.CapacityReached += HandleCapacityReached;
        }

        private void HandleCapacityReached(object? sender, CapacityReachedEventArgs e)
        {
            _consoleLogger($"[ALERTA DE CAPACIDADE] Pacote '{e.PacoteTitulo}' (ID: {e.PacoteId}) atingiu ou excedeu a capacidade máxima de {e.CapacidadeMaxima}. Reservas Atuais: {e.ReservasAtuais}.");
        }

        private void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public IActionResult OnPostAddReservation()
        {
            var newReserva = new ReservaForEvent
            {
                Id = CurrentPackage.Reservas.Count + 1,
                PacoteTuristicoId = CurrentPackage.Id,
                DataReserva = DateTime.Now
            };

            CurrentPackage.AdicionarReserva(newReserva);

            return Page();
        }

    }
}