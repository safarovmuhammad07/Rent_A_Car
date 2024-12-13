using DoMain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class LocationServiceController(ILocationService locationService):ControllerBase
{
    [HttpGet]
    public Responce<List<Location>> GetLocations()
    {
        return locationService.GetLocations();
    }

    [HttpGet("{id}")]
    public Responce<Location> GetLocation(int id)
    {
        return locationService.GetLocationById(id);
    }

    [HttpPost]
    public Responce<bool> PostLocation(Location location)
    {
        return locationService.AddLocation(location);
    }

    [HttpPut("{id}")]
    public Responce<bool> PutLocation(Location location)
    {
        return locationService.UpdateLocation(location);
    }

    [HttpDelete]
    public Responce<bool> DeleteLocation(int id)
    {
        return locationService.DeleteLocation(id);
    }
}