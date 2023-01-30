using Demo_Crud_For_Customer.Entity;

namespace Demo_Crud_For_Customer.Repository
{
    public interface ICustomer
    {
        Task<bool> CreateCustomer(Customer customer);
        Task<bool> DeleteCustomer(int id);
        Task<bool> UpdateCustomer(Customer customer);
        Task<Customer> GetCustomerById(int id);
    }
}
