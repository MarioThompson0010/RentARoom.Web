using RentARoom.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace RentARoom.Web.Services
{
    public class GetClients : IGetClients
    {
        private readonly HttpClient httpClient;

        public GetClients(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<RentARoom.Models.MyClient>> GetMyClientsBlz()
        {
            var temp = await httpClient.GetFromJsonAsync<RentARoom.Models.MyClient[]>("api/MyClients");
            return temp;
        }

        public async Task<RentARoom.Models.MyClientSub> GetClientBlz(int id)
        {////

            var temp = await httpClient.GetFromJsonAsync<RentARoom.Models.MyClientSub>($"api/MyClients/{id}");
            return temp;
        }
    }
}
