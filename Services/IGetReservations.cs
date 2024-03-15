using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentARoom.Web.Services
{
    public interface IGetReservations
    {

        Task<IEnumerable<RentARoom.Models.MyReservation>> GetMyReservationsBlz();
        Task<RentARoom.Models.MyReservation> GetReservationBlz(int id);
        Task<RentARoom.Models.MakeReservationOutputSP> MakeReservationBlz(string email, string phone);
        Task<RentARoom.Models.DeleteReservationOutputSP> DeleteReservationBlz(int id);
    }
}
