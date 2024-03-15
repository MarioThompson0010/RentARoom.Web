using RentARoom.Models;
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

    public async Task<IEnumerable<RentARoom.Models.MyReservation>> GetMyReservationsBlz()
    {//
      var temp = await httpClient.GetFromJsonAsync<RentARoom.Models.MyReservation[]>("api/MyReservation");
      return temp;
    }

    public async Task<RentARoom.Models.MyReservation> GetReservationBlz(int id)
    {
      var temp = await httpClient.GetFromJsonAsync<RentARoom.Models.MyReservation>($"api/MyReservation/{id}");
      return temp;
    }

    public async Task<RentARoom.Models.MakeReservationOutputSP> MakeReservationBlz(string email, string phone)
    {
      var resinput = new RentARoom.Models.MakeReservationInputSP() { Email = email, Phone = phone };
      RentARoom.Models.MakeReservationOutputSP output = new MakeReservationOutputSP();
      var response = await httpClient.PostAsJsonAsync<RentARoom.Models.MakeReservationInputSP>($"api/MakeReservationOutput", resinput);
      try
      {
        var temp = await response.Content.ReadFromJsonAsync<List<RentARoom.Models.MakeReservationOutputSP>>();
        return temp.FirstOrDefault();

      }
      catch (System.Exception)
      {

        return null;
      }


    }

    public async Task<RentARoom.Models.DeleteReservationOutputSP> DeleteReservationBlz(int id)
    {
      RentARoom.Models.DeleteReservationInputSP delinput = new RentARoom.Models.DeleteReservationInputSP() { ReservationId = id };
      RentARoom.Models.DeleteReservationOutputSP output = new RentARoom.Models.DeleteReservationOutputSP();
      try
      {
        var response = await httpClient.PostAsJsonAsync<RentARoom.Models.DeleteReservationInputSP>($"api/DeleteReservationOutput", delinput);

        var temp = await response.Content.ReadFromJsonAsync<RentARoom.Models.DeleteReservationOutputSP>();

        return temp;
      }
      catch (System.Exception)
      {

        return null;
      }

    }
  }
}
