using Cubits.Domain.Entities;
using Cubits.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubits.Infraestructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public async Task<Client> Get(int clientid)
        {
            await Task.Delay(100);
            return new Client
            {
                ClientId = clientid,
                Name = "Evaluna",
                StreetName = "Canada",
                City = "San Fco",
                Province="Cordoba",
                Region="Este"
            };
        }

        public async Task<List<Client>> GetList()
        {
            await Task.Delay(100);
            return new List<Client>
        {
            new Client
            {
                ClientId = 1,
                Name="Roman",
                StreetName = "Canada",
                City = "San Fco",
                Province="Cordoba",
                Region="Sur"
            }
        };
        }
    }
}
