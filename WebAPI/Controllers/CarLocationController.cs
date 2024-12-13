using DoMain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CarLocationController(CarLocationService carLocation):ControllerBase
{
    [HttpGet]
    public Responce<List<CarLocation>> Get()
    {
        return carLocation.GetCarLocations();
    }

    [HttpGet("{id}")]
    public Responce<CarLocation> Get(int id)
    {
        return carLocation.GetCarLocation(id);  
    }

    [HttpPost]
    public Responce<bool> Post(CarLocation carLocationn)
    {
        return carLocation.AddCarLocation( carLocationn);
    }

    [HttpPut]
    public Responce<bool> Put(CarLocation carLocationn)
    {
        return carLocation.UpdateCarLocation(carLocationn);
    }

    [HttpDelete]
    public Responce<bool> Delete(int id)
    {
        return carLocation.DeleteCarLocation(id);
    }
    
    
    
    
}