using  CustomerService.Model;

// Interface Implementation for CustomerRepository
namespace CustomerService.Repository{
    public interface ICustomerRepository{
        IEnumerable<Customer> GetCustomers();
        void AddCustomers(IEnumerable<Customer> newCustomers);
    }
}