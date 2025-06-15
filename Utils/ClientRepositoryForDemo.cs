using CityBreaks.Agency.Models;

namespace CityBreaks.Agency.Utils
{
    public class ClientRepositoryForDemo
    {
        private static List<Cliente> _clients = new List<Cliente>
           {
               new Cliente { Id = 1, Nome = "João Silva", Email = "joao.silva@email.com" },
               new Cliente { Id = 2, Nome = "Maria Oliveira", Email = "maria.o@email.com" },
               new Cliente { Id = 3, Nome = "Carlos Santos", Email = "carlos.s@email.com" }
           };

        public static Cliente? GetById(int id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }

        public static void Add(Cliente newClient)
        {
            newClient.Id = _clients.Any() ? _clients.Max(c => c.Id) + 1 : 1;
            _clients.Add(newClient);
        }

        public static List<Cliente> GetAll()
        {
            return _clients;
        }
    }
}
