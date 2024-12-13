using Dapper;
using DoMain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class CustomerService(DapperContext context):ICustomerService
{
    public List<Customer> GetCustomers()
    {
        var sql = "select * from Customer";
        return context.GetConnection().Query<Customer>(sql).ToList();
    }

    public Customer GetCustomerById(int id)
    {
        var sql = "select * from Customer where id=@id";
        return context.GetConnection().Query<Customer>(sql, new { id }).FirstOrDefault();
    }

    public bool AddCustomer(Customer customer)
    {
        var sql = " insert into Customer(FirstName,LastNAme,Email,Phone,Address) values (@FirstName,@LastNAme,@Email,@Phone,@Address)";
        return context.GetConnection().Execute(sql, customer)>0;
        
    }

    public bool UpdateCustomer(Customer customer)
    {
        var sql = "Update Customer set FirstName=@FirstName, LastName=@LastNAme, Email=@Email, Phone=@Phone, Address=@Address";
        return context.GetConnection().Execute(sql, customer)>0;
    }

    public bool DeleteCustomer(Customer customer)
    {
        var sql = "delete from Customer where id=@id";
        return context.GetConnection().Execute(sql, customer)>0;
    }
}