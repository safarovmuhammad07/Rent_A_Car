using DoMain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController(ICarService carService):ControllerBase
{
    [HttpGet]
    public Responce<List<Car>> Get()
    {
          return  carService.GetCars();
    }

    [HttpGet("{id}")]
    public Responce<Car> Get(int id)
    {
        return carService.GetCarById(id);
    }

    [HttpPost]
    public Responce<bool> Post(Car car)
    {
        return carService.AddCar(car);
    }

    [HttpPut]
    public Responce<bool> Put(Car car)
    {
        return carService.UpdateCar(car);
    }

    [HttpDelete]
    public Responce<bool> Delete(int id)
    {
        return carService.DeleteCar(id);
    }
    
    
    
    
    
    
    
    
}