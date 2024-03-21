using RentARoom.Models.Reservations;
using RentARoom.Models.Clients;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Linq;
using System.Numerics;

namespace RentARoom.Web.Services
{
	public class GetReservations : IGetReservations
	{
		private readonly HttpClient httpClient;

		public GetReservations(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<IEnumerable<RentARoom.Models.Reservations.MyReservation>> GetMyReservationsBlz()
		{//
			var temp = await httpClient.GetFromJsonAsync<RentARoom.Models.Reservations.MyReservation[]>("api/MyReservation");
			return temp;
		}

		public async Task<RentARoom.Models.Reservations.MyReservation> GetReservationBlz(int id)
		{
			var temp = await httpClient.GetFromJsonAsync<RentARoom.Models.Reservations.MyReservation>($"api/MyReservation/{id}");
			return temp;
		}

		public async Task<RentARoom.Models.Reservations.MakeReservationOutputSP> MakeReservationBlz(string email, string phone)
		{
			var resinput = new RentARoom.Models.Reservations.MakeReservationInputSP() { Email = email, Phone = phone };
			RentARoom.Models.Reservations.MakeReservationOutputSP output = new MakeReservationOutputSP();
			var response = await httpClient.PostAsJsonAsync<RentARoom.Models.Reservations.MakeReservationInputSP>($"api/MakeReservationOutput", resinput);
			try
			{
				var temp = await response.Content.ReadFromJsonAsync<List<RentARoom.Models.Reservations.MakeReservationOutputSP>>();
				return temp.FirstOrDefault();

			}
			catch (System.Exception)
			{

				return null;
			}


		}

		public async Task<DeleteReservationOutputSP> DeleteReservationBlz(int id)
		{
			DeleteReservationInputSP delinput = new DeleteReservationInputSP() { ReservationId = id };
			try
			{
				var response = await httpClient.PostAsJsonAsync<DeleteReservationInputSP>($"api/DeleteReservationOutput", delinput);

				var temp = await response.Content.ReadFromJsonAsync<DeleteReservationOutputSP>();
				if (temp == null)
				{
					return new DeleteReservationOutputSP();
				}

				return temp;
			}
			catch (System.Exception)
			{

				return null;
			}

		}
	}
}
