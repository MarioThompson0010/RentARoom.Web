using RentARoom.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Linq;

namespace RentARoom.Web.Services
{
    public class GetClients : IGetClients
    {
        private readonly HttpClient httpClient;
        private int Id { get; set; } = 0;

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
        {//////
            this.Id = id;
            var temp = await httpClient.GetFromJsonAsync<RentARoom.Models.MyClientSub>($"api/MyClients/{id}");
            return temp;
        }

        public async Task<RentARoom.Models.MyClientSub> UpdateClientBlz(RentARoom.Models.MyClient myClient)
        {
            //var temp = await httpClient.GetFromJsonAsync<RentARoom.Models.MyClientSub>($"api/MyClients/{id}");
            //RentARoom.Models.MyClient toput = new MyClient() { Id = id, Email  }
            var tempClientFull = await httpClient.PutAsJsonAsync<RentARoom.Models.MyClient>($"api/MyClients/{this.Id}", myClient);
            var temp = await tempClientFull.Content.ReadFromJsonAsync<RentARoom.Models.MyClient>();
            var sub = CommandLineEF.Controllers.MyClientsController.TranslateFromFullToSub(temp);//.FirstOrDefault());
            return sub;
        }
    }
}
