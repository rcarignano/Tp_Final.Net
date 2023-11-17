using Cubits.Domain.Entities;
using Cubits.Domain.Ports;
using Cubits.Infraestructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubits.Infraestructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly SqlServerContext _dbContext;

        public ClientRepository(SqlServerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Client?> Get(int clientId)
        {
            return await _dbContext
            .Set<Client>()
            .Where(c => c.ClientId == clientId)
            .FirstOrDefaultAsync();
        }

        public async Task<List<Client>> GetList()
        {
            return await _dbContext
           .Set<Client>()
           .ToListAsync();
        }
    }
}
