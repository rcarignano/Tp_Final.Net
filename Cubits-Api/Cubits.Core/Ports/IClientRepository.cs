using Cubits.Domain.Entities;
using System.Linq.Expressions;

namespace Cubits.Domain.Ports
{
    public interface IClientRepository
    {
        Task<List<Client>> GetList();

        Task<Client> Get(int clientId);
    }
}
