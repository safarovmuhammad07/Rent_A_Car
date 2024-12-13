using Dapper;
using DoMain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class CarService(DapperContext context): ICarService
{
    public List<Car> GetCars()
    {
        var sql = "select * from Car";
        return context.GetConnection().Query<Car>(sql).ToList();
    }

    public Car GetCarById(int carId)
    {
        var sql = "select * from Car where Id = @Id";
        return context.GetConnection().Query<Car>(sql, new { Id = carId }).FirstOrDefault();
    }

    public bool AddCar(Car car)
    {
        var sql= " Insert into Car(Name,Model,Price,Image) values (@Name,@Model,@Price,@Image)";
        return context.GetConnection().Execute(sql, car)>0;
    }

    public bool UpdateCar(Car car)
    {
        var sql= "Update Car set Name=@Name,Model=@Model,Price=@Price,Image=@Image";
        return context.GetConnection().Execute(sql, car)>0;
        
    }

    public bool DeleteCar(int carId)
    {
        var sql = "Delete from Car where Id = @Id";
        return context.GetConnection().Execute(sql, new { Id = carId }) > 0;
    }
}