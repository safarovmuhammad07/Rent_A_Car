using Dapper;
using DoMain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class RentalService(DapperContext context): IRentalService
{
    public List<Rental> GetRentals()
    {
        var sql = "select * from Rental";
        return context.GetConnection().Query<Rental>(sql).ToList();
        
    }

    public Rental GetRentalById(int id)
    {
       var sql = "select * from Rental where Id = @Id";
       return context.GetConnection().Query<Rental>(sql, new { Id = id }).FirstOrDefault();
       
    }

    public bool AddRental(Rental rental)
    {
        var sql = "insert into Rentals(CarId, CustomerId, StartDate, EndDate, TotalCost) values (@CarId, @CustomerId, @StartDate, @EndDate, @TotalCost);\n";
        var res = context.GetConnection().Execute(sql, rental);
        return res > 0;
    }

    public bool UpdateRental(Rental rental)
    {
        var sql ="Update Rentals set TotalCost = @TotalCost, StartDate=@StartDate,EndDate=@EndDate where Id = @Id";
        return context.GetConnection().Execute(sql, rental)>0;
    }

    public bool DeleteRental(int id)
    {
        var sql = "delete from Rentals where Id = @Id";
        return context.GetConnection().Execute(sql, new { Id = id }) > 0;
    }
}