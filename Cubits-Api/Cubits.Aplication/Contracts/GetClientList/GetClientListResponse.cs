using Cubits.Application.Models;

namespace Cubits.Application.Contracts.GetClientList
{
    public class GetClientListResponse
    {
        public List<ClientDto>? ClientList { get; set; }
    }
}
