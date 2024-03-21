using System.Collections.Generic;
using System.Threading.Tasks;
using RentARoom.Models.Reservations;

namespace RentARoom.Web.Services
{
    public interface IGetReservations
    {

        Task<IEnumerable<MyReservation>> GetMyReservationsBlz();
        Task<MyReservation> GetReservationBlz(int id);
        Task<MakeReservationOutputSP> MakeReservationBlz(string email, string phone);
        Task<DeleteReservationOutputSP> DeleteReservationBlz(int id);
    }
}
