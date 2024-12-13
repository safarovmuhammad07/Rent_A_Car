using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class CustomerService(DapperContext context):ICustomerService
{
    public Responce<List<Customer>> GetCustomers()
    {
        var sql = "select * from Customer";
        var res = context.GetConnection().Query<Customer>(sql).ToList();
        return new Responce<List<Customer>>(res);
    }

    public Responce<Customer> GetCustomerById(int id)
    {
        var sql = "select * from Customer where id=@id";
        var res = context.GetConnection().Query<Customer>(sql, new { id }).FirstOrDefault();
        return res == null ? new Responce<Customer>(HttpStatusCode.NotFound , "Customer not found") : new Responce<Customer>(res);
    }

    public Responce<bool> AddCustomer(Customer customer)
    {
        var sql = " insert into Customer(FirstName,LastNAme,Email,Phone,Address) values (@FirstName,@LastNAme,@Email,@Phone,@Address)";
        var res= context.GetConnection().Execute(sql, customer);
        
        return res==0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Server Eror") : new Responce<bool>(HttpStatusCode.Created, "Customer added");
    }

    public Responce<bool> UpdateCustomer(Customer customer)
    {
        var sql = "Update Customer set FirstName=@FirstName, LastName=@LastNAme, Email=@Email, Phone=@Phone, Address=@Address";
        var res= context.GetConnection().Execute(sql, customer);
        return res==0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Server Eror") : new Responce<bool>(HttpStatusCode.OK, "Customer updated");
    }

   
    public Responce<bool> DeleteCustomer(int id)
    {
        var sql = "delete from Customer where id=@id";
        var res=  context.GetConnection().Execute(sql, new{id});
        
        return res==0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Server Eror") : new Responce<bool>(HttpStatusCode.OK, "Customer deleted");
    }
}