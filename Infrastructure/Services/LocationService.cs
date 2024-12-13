using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class LocationService(DapperContext context): ILocationService
{
    public Responce<List<Location>> GetLocations()
    {
        var sql = "select * from Location";
        var res  = context.GetConnection().Query<Location>(sql).ToList();
        
        return new Responce<List<Location>>(res);
        
    }

    public Responce<Location> GetLocationById(int id)
    {
        var sql = "select * from Location where Id = @Id";
        var res = context.GetConnection().Query<Location>(sql, new { Id = id }).FirstOrDefault();
        return res == null ? new Responce<Location>(HttpStatusCode.NotFound, "Location not found") :  new Responce<Location>(res);
    }

    public Responce<bool> AddLocation(Location location)
    {
        var sql = "insert into Location (Name) values (@Name)";
        var res= context.GetConnection().Execute(sql, location) ;
        return res==0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error") : new Responce<bool>(HttpStatusCode.OK, "Location added");
    }

    public Responce<bool> UpdateLocation(Location location)
    {
        var sql = "update Location set Name = @Name where Id = @Id";
        var res  =context.GetConnection().Execute(sql, location);
        return res==0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error") : new Responce<bool>(HttpStatusCode.OK, "Location updated");
    }

    public Responce<bool> DeleteLocation(int id)
    {
        var sql = "delete from Location where Id = @Id";
        var res =context.GetConnection().Execute(sql, new { Id = id }) ;
        if (res==0)
            return new Responce<bool>(HttpStatusCode.NotFound, "Location not found");
        return new Responce<bool>(HttpStatusCode.OK, "Location deleted");
    }
}