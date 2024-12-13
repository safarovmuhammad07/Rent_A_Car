using DoMain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Interfaces;

public interface IRentalService
{
    Responce<List<Rental>> GetRentals();
    Responce<Rental> GetRentalById(int id);
    Responce<bool> AddRental(Rental rental);
    Responce<bool> UpdateRental(Rental rental);
    Responce<bool> DeleteRental(int id);
}