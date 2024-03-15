using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using RentARoom.Models;
using System.Threading.Tasks;
using RentARoom.Web.Services;
//using CommandLineEF.Models;
using System.Linq;


namespace RentARoom.Web.Pages
{
    public class DisplayClientsBase :ComponentBase
    {

        [Inject]
        public IGetClients GetClientService { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }


        [Parameter]
        public string Id { get; set; }

        public IEnumerable<RentARoom.Models.MyClient> MyClients { get; set; }
        public RentARoom.Models.MyClient MyClient { get; set; }
        public RentARoom.Models.MyClientSub MyClientSub { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.MyClients = (await GetClientService.GetMyClientsBlz()).ToList();// ToList();
        
        }

        protected void ToggleNavMenu()
        {
            Navigation.NavigateTo("DisplayReservations");
        }

        protected async void LookupClientById()
        {
            int.TryParse(Id, out var intId);
            this.MyClientSub = (await GetClientService.GetClientBlz(intId));// ToList();
            
            this.StateHasChanged();
        }
        
    }
}
