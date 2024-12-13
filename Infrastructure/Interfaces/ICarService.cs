using DoMain.Models;

namespace Infrastructure.Interfaces;

public interface ICarService
{
    List<Car> GetCars();
    Car GetCarById(int carId);
    bool AddCar(Car car);
    bool UpdateCar(Car car);
    bool DeleteCar(int carId);
}