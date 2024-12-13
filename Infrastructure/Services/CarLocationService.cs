using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class CarLocationService(DapperContext context): ICarLocationService 
{
    public Responce<List<CarLocation>> GetCarLocations()
    {
        var sql = "select * from CarLocation";
        var cars= context.GetConnection().Query<CarLocation>(sql).ToList();
        return new Responce<List<CarLocation>>(cars);
    }

    public Responce<CarLocation> GetCarLocation(int carId)
    {
        var sql = "select * from CarLocation where CarId = @CarId";
         var car =context.GetConnection().Query<CarLocation>(sql, new { CarId = carId }).FirstOrDefault();
         
         return car == null 
             ? new Responce<CarLocation>(HttpStatusCode.NotFound, "Car Not Found") 
             : new Responce<CarLocation>(car);
    }

    public Responce<bool> AddCarLocation(CarLocation carLocation)
    {
        var sql = "insert into CarLocation (CarId, LocationId) values (@CarId, @LocationId)";
        var car= context.GetConnection().Execute(sql, carLocation);
        return car==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<bool>(HttpStatusCode.Created, "Car successfully added    ");
    }

    public  Responce<bool> UpdateCarLocation(CarLocation carLocation)
    {
        var sql = "update CarLocation set LocationId = @LocationId where CarId = @CarId";
        var car =context.GetConnection().Execute(sql, carLocation);
        return car == 0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<bool>(HttpStatusCode.OK, "Car Location Updated");
        
    }

    public  Responce<bool> DeleteCarLocation(int carId)
    {
        var sql = "delete from CarLocation where CarId = @CarId";
        var car = context.GetConnection().Execute(sql, new { CarId = carId }) ;
        return car == 0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<bool>(HttpStatusCode.OK, "Car Location Deleted");
    }
}