using DoMain.Models;

namespace Infrastructure.Interfaces;

public interface ICustomerService
{
    List<Customer> GetCustomers();
    Customer GetCustomerById(int id);
    bool AddCustomer(Customer customer);
    bool UpdateCustomer(Customer customer);
    bool DeleteCustomer(Customer customer);
}