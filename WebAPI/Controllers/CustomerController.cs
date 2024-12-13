using DoMain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;



[ApiController]
[Route("[controller]")]
public class CustomerController(ICustomerService customerService):ControllerBase
{
    [HttpGet]
    public Responce<List<Customer>> GetCustomers()
    {
        return customerService.GetCustomers();
    }

    [HttpGet("{id}")]
    public Responce<Customer> GetCustomer(int id)
    {
        return customerService.GetCustomerById(id);
    }

    [HttpPost]
    public Responce<bool> AddCustomer(Customer customer)
    {
        return customerService.AddCustomer(customer);
    }

    [HttpPut]
    public Responce<bool> UpdateCustomer(Customer customer)
    {
        return  customerService.UpdateCustomer(customer);
    }

    [HttpDelete]
    public Responce<bool> DeleteCustomer(int id)
    {
        return customerService.DeleteCustomer(id);
    }
    
    
    
    
}