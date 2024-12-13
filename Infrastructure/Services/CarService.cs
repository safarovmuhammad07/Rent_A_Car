using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class CarService(DapperContext context): ICarService
{
    public Responce<List<Car>> GetCars()
    {
        var sql = "select * from Car";
        var cars= context.GetConnection().Query<Car>(sql).ToList();
        return new Responce<List<Car>>(cars);
    }

    public Responce<Car> GetCarById(int carId)
    {
        var sql = "select * from Car where Id = @Id";
        var car =context.GetConnection().Query<Car>(sql, new { Id = carId }).FirstOrDefault();
        return car == null ? new Responce<Car>(HttpStatusCode.NotFound,"Not found") : new Responce<Car>(car);
    }

    public Responce<bool> AddCar(Car car)
    {
        var sql= " Insert into Car(Name,Model,Price,Image) values (@Name,@Model,@Price,@Image)";
        var res= context.GetConnection().Execute(sql, car);
        return res == 0 ? new Responce<bool>(HttpStatusCode.InternalServerError,"Internal Server Error") : new Responce<bool>(HttpStatusCode.Created, "Created successfully");
    }

    public Responce<bool> UpdateCar(Car car)
    {
        var sql= "Update Car set Name=@Name,Model=@Model,Price=@Price,Image=@Image";
        var res = context.GetConnection().Execute(sql, car);
        
        return res == 0 ? new Responce<bool>(HttpStatusCode.NotFound,"Not found") : new Responce<bool>(HttpStatusCode.OK, "Updated successfully");
    }

    public Responce<bool> DeleteCar(int carId)
    {
        var sql = "Delete from Car where Id = @Id";
        var res= context.GetConnection().Execute(sql, new { Id = carId }) ;
        return res==0 ? new Responce<bool>(HttpStatusCode.NotFound,"Not found") : new Responce<bool>(HttpStatusCode.OK,"Deleted successfully");
    }
}