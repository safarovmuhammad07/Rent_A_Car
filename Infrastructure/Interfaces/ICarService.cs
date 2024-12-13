using DoMain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Interfaces;

public interface ICarService
{
    Responce<List<Car>> GetCars();
    Responce<Car> GetCarById(int carId);
    Responce<bool> AddCar(Car car);
    Responce<bool> UpdateCar(Car car);
    Responce<bool> DeleteCar(int carId);
}