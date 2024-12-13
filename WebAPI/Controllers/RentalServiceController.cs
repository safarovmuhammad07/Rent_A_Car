using DoMain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RentalServiceController(IRentalService service):ControllerBase
{
    [HttpGet]
    public Responce<List<Rental>> Get()
    {
        return service.GetRentals();
    }

    [HttpGet("{id}")]
    public Responce<Rental> Get(int id)
    {
        return service.GetRentalById(id);
    }

    [HttpPost]
    public Responce<bool> Post(Rental value)
    {
        return service.AddRental(value);
    }

    [HttpPut("{id}")]
    public Responce<bool> Put( Rental value)
    {
        return service.UpdateRental(value);
    }

    [HttpDelete]
    public Responce<bool> Delete(int id)
    {
        return service.DeleteRental(id);
    }
    
    
}