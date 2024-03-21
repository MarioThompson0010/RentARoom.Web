using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentARoom.Web.Services
{
    public interface IGetClients
    {
        Task<IEnumerable</*RentARoom.Models.*/RentARoom.Models.Clients.MyClient>> GetMyClientsBlz();
        Task<RentARoom.Models.Clients.MyClientSub> GetClientBlz(int id);
        Task<RentARoom.Models.Clients.MyClientSub> UpdateClientBlz(RentARoom.Models.Clients.MyClient myClient);

    }
}
