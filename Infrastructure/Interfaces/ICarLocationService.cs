using DoMain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Interfaces;

public interface ICarLocationService
{
    Responce<List<CarLocation>> GetCarLocations();
    Responce<CarLocation> GetCarLocation(int carId);
    Responce<bool> AddCarLocation(CarLocation carLocation);
    Responce<bool> UpdateCarLocation(CarLocation carLocation);
    Responce<bool> DeleteCarLocation(int carId);
}