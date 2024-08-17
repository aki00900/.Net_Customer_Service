using Microsoft.AspNetCore.Mvc;
using CustomerService.Model;
using CustomerService.Repository;

namespace CustomerService.Controllers
{   
    // Controller class for handling all HTTP requests.
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase{ 
    private readonly ICustomerRepository customerRepository;

    // Constructor that injects the customer repository interface.
    public CustomerController(ICustomerRepository customerRepository){
        this.customerRepository = customerRepository;
    }

    
    [HttpGet] // Handles HTTP GET requests to retrieve a list of all sorted order customers.
    public IEnumerable<Customer> GetCustomers()
    {
        return customerRepository.GetCustomers();
        
    }

    [HttpPost()] // Handles HTTP POST requests to create new customers.
    public ActionResult<Customer> CreateCustomer([FromBody] IEnumerable<Customer> newCustomers)
   {
        try{
            // Adding new customers using the repository.
            customerRepository.AddCustomers(newCustomers);
            return Ok("Customers added successfully.");
        }
        catch (InvalidOperationException ex){
            // Return a BadRequest response; if validation or insertion fails.
            return BadRequest($"Invalid Input provided: {ex.Message}");
        }
   }
}
}