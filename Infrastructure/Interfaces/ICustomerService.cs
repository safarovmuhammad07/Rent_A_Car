using DoMain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Interfaces;

public interface ICustomerService
{
    Responce<List<Customer>> GetCustomers();
    Responce<Customer> GetCustomerById(int id);
    Responce<bool> AddCustomer(Customer customer);
    Responce<bool> UpdateCustomer(Customer customer);
    Responce<bool> DeleteCustomer(int id);
}