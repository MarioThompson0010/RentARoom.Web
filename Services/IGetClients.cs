using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentARoom.Web.Services
{
    public interface IGetClients
    {
        Task<IEnumerable</*RentARoom.Models.*/RentARoom.Models.MyClient>> GetMyClientsBlz();
        Task<RentARoom.Models.MyClientSub> GetClientBlz(int id);

    }
}
