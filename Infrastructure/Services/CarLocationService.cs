using Dapper;
using DoMain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class CarLocationService(DapperContext context): ICarLocationService 
{
    public List<CarLocation> GetCarLocations()
    {
        var sql = "select * from CarLocation";
        return context.GetConnection().Query<CarLocation>(sql).ToList();
    }

    public CarLocation GetCarLocation(int carId)
    {
        var sql = "select * from CarLocation where CarId = @CarId";
        return context.GetConnection().Query<CarLocation>(sql, new { CarId = carId }).FirstOrDefault();
    }

    public bool AddCarLocation(CarLocation carLocation)
    {
        var sql = "insert into CarLocation (CarId, LocationId) values (@CarId, @LocationId)";
        return context.GetConnection().Execute(sql, carLocation)>0;
    }

    public bool UpdateCarLocation(CarLocation carLocation)
    {
        var sql = "update CarLocation set LocationId = @LocationId where CarId = @CarId";
        return context.GetConnection().Execute(sql, carLocation)>0;
    }

    public bool DeleteCarLocation(int carId)
    {
        var sql = "delete from CarLocation where CarId = @CarId";
        return context.GetConnection().Execute(sql, new { CarId = carId }) > 0;
    }
}