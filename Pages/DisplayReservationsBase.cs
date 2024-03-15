﻿using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using RentARoom.Models;
using System.Threading.Tasks;
using RentARoom.Web.Services;
//using CommandLineEF.Models;
using System.Linq;


namespace RentARoom.Web.Pages
{
    public class DisplayReservationsBase : ComponentBase
    {

        [Inject]
        public IGetReservations GetReservationService { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id {get; set;}

        [Parameter]
        public string Email { get; set; }


        [Parameter]
        public string Phone { get; set; }


        public IEnumerable<RentARoom.Models.MyReservation> MyReservations { get; set; }
        public RentARoom.Models.MyReservation MyReservation { get; set; }
        public RentARoom.Models.MyReservationSub MyReservationSub { get; set; }
        public RentARoom.Models.MakeReservationOutputSP MakeReservation { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.MyReservations = (await GetReservationService.GetMyReservationsBlz()).ToList();
//        
        }

        protected async void ToggleNavMenu()
        {
            this.MyReservations = (await GetReservationService.GetMyReservationsBlz()).ToList();// ToList();
            this.StateHasChanged();
        }

        protected async void LookupReservationById()
        {
            int.TryParse(Id, out var intId);
            this.MyReservation = (await GetReservationService.GetReservationBlz(intId ));// ToList();
            
            this.StateHasChanged();
        }


        protected async void MakeReservationByEmail()
        {
            string email = this.Email ?? "";
            string phone = this.Phone == "" ? null : this.Phone;
            this.MakeReservation = (await GetReservationService.MakeReservationBlz(email, phone));// ToList();

            this.StateHasChanged();
        }

    }
}
