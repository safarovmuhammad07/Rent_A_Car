using DoMain.Models;

namespace Infrastructure.Interfaces;

public interface ILocationService
{
    List<Location> GetLocations();
    Location GetLocationById(int id);
    bool AddLocation(Location location);
    bool UpdateLocation(Location location);
    bool DeleteLocation(int id);
}