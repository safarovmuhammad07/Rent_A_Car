using DoMain.Models;

namespace Infrastructure.Interfaces;

public interface IRentalService
{
    List<Rental> GetRentals();
    Rental GetRentalById(int id);
    bool AddRental(Rental rental);
    bool UpdateRental(Rental rental);
    bool DeleteRental(int id);
}