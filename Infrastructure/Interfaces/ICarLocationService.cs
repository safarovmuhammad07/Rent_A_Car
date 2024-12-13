using DoMain.Models;

namespace Infrastructure.Interfaces;

public interface ICarLocationService
{
    List<CarLocation> GetCarLocations();
    CarLocation GetCarLocation(int carId);
    bool AddCarLocation(CarLocation carLocation);
    bool UpdateCarLocation(CarLocation carLocation);
    bool DeleteCarLocation(int carId);
}