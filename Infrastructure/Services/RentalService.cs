using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class RentalService(DapperContext context): IRentalService
{
    public Responce<List<Rental>> GetRentals()
    {
        var sql = "select * from Rental";
        var res= context.GetConnection().Query<Rental>(sql).ToList();
        return new Responce<List<Rental>>(res);
        
    }

    public Responce<Rental> GetRentalById(int id)
    {
       var sql = "select * from Rental where Id = @Id";
       var res= context.GetConnection().Query<Rental>(sql, new { Id = id }).FirstOrDefault();
       if(res == null)
           return new Responce<Rental>(HttpStatusCode.NotFound, "Rental not found");
       return new Responce<Rental>(res);
       
    }

    public Responce<bool> AddRental(Rental rental)
    {
        var sql = "insert into Rentals(CarId, CustomerId, StartDate, EndDate, TotalCost) values (@CarId, @CustomerId, @StartDate, @EndDate, @TotalCost);\n";
        var res = context.GetConnection().Execute(sql, rental);
        return res == 0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval SERVER EROR"): new Responce<bool>(HttpStatusCode.Created, "Created Rental");
    }

    public Responce<bool> UpdateRental(Rental rental)
    {
        var sql ="Update Rentals set TotalCost = @TotalCost, StartDate=@StartDate,EndDate=@EndDate where Id = @Id";
        var res =context.GetConnection().Execute(sql, rental);
        return res==0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval SERVER EROR"): new Responce<bool>(HttpStatusCode.OK, "Rental Updated");
    }

    public Responce<bool> DeleteRental(int id)
    {
        var sql = "delete from Rentals where Id = @Id";
        var res = context.GetConnection().Execute(sql, new { Id = id }) ;
        return res==0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval SERVER EROR"): new Responce<bool>(HttpStatusCode.OK, "Rental Deleted");
    }
}