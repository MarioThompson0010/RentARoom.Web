using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using RentARoom.Models;
using System.Threading.Tasks;
using RentARoom.Web.Services;
//using CommandLineEF.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace RentARoom.Web.Pages
{
    public class DisplayHomeBase :ComponentBase
    {

        //[Inject]
        //public IGetClients GetClientService { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }


        //[Parameter]
        //public string Id { get; set; }

        //[Parameter]
        //public string FirstName { get; set; }

        //[Parameter]
        //public string LastName { get; set; }

        //[Parameter]
        //public string PhoneNumber { get; set; }

        //[Parameter]
        //public string Email { get; set; }


        //public IEnumerable<RentARoom.Models.Clients.MyClient> MyClients { get; set; }
        //public RentARoom.Models.Clients.MyClient MyClient { get; set; }
        //public RentARoom.Models.Clients.MyClientSub MyClientSub { get; set; }

        //protected override async Task OnInitializedAsync()
        //{
        //    //this.MyClients = (await GetClientService.GetMyClientsBlz()).ToList();// ToList();
        ////
        //}

        protected void MakeOrSeeReservations()
        {
            //Navigation.NavigateTo("DisplayReservations");
        }

        protected void LookupClientById()
        {
			Navigation.NavigateTo($"DisplayClients");

			//         int.TryParse(Id, out var intId);

			//         if (intId == 0)
			//         {
			//             Navigation.NavigateTo($"DisplayClient");
			//         }
			//         else
			//         {
			//             Navigation.NavigateTo($"DisplayClient/{this.Id}");

			//             this.MyClientSub = (await GetClientService.GetClientBlz(intId));// ToList();
			//             if (this.MyClientSub != null)
			//             {
			//                 this.Email = this.MyClientSub.Email?.Trim();// MyClientSub.Email;
			//                 this.PhoneNumber = this.MyClientSub.Phone?.Trim();// MyClientSub.Phone;
			//                 this.FirstName = this.MyClientSub.FirstName?.Trim();
			//                 this.LastName = this.MyClientSub.LastName?.Trim();
			//             }
			//         }
			//this.StateHasChanged();
		}

		//protected async void UpdateClientOne()
  //      {

  //          //int.TryParse(this.Id, out var intId);
  //          //RentARoom.Models.Clients.MyClient passclient = new RentARoom.Models.Clients.MyClient()
  //          //{
  //          //    Id = intId,
  //          //    Email = this.Email,
  //          //    FirstName = this.FirstName,
  //          //    LastName = this.LastName,
  //          //    Phone = this.PhoneNumber
  //          //};
  //          //this.MyClientSub = (await GetClientService.UpdateClientBlz(passclient));// ToList();
  //          ////var temp = (await GetClientService.UpdateClientBlz())
  //          //this.StateHasChanged();
  //      }

    }
}
