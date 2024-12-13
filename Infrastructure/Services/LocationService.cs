using Dapper;
using DoMain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class LocationService(DapperContext context): ILocationService
{
    public List<Location> GetLocations()
    {
        var sql = "select * from Location";
        return context.GetConnection().Query<Location>(sql).ToList();
    }

    public Location GetLocationById(int id)
    {
        var sql = "select * from Location where Id = @Id";
        return context.GetConnection().Query<Location>(sql, new { Id = id }).FirstOrDefault();
    }

    public bool AddLocation(Location location)
    {
        var sql = "insert into Location (Name) values (@Name)";
        return context.GetConnection().Execute(sql, location) > 0;
        
    }

    public bool UpdateLocation(Location location)
    {
        var sql = "update Location set Name = @Name where Id = @Id";
        return context.GetConnection().Execute(sql, location) > 0;
    }

    public bool DeleteLocation(int id)
    {
        var sql = "delete from Location where Id = @Id";
        return context.GetConnection().Execute(sql, new { Id = id }) > 0;
    }
}