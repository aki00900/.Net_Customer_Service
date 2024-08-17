using CustomerService.Model;
using Newtonsoft.Json;

namespace CustomerService.Repository{
    
    // This class represents a repository for managing customer data with interface implemented
    public class CustomerRepository : ICustomerRepository
    { 
        // A list to store customer objects.
        private readonly List<Customer> customers = new List<Customer>();

        // The path to the JSON file used for data storage.
        private readonly string dataFilePath = "customerData.json";

        // Constructor that loads data from the JSON file when an instance of this class is created.
        public CustomerRepository()
        {
            LoadData();
        }

        // Retrieves all customers in the repository.
        public IEnumerable<Customer> GetCustomers()
        {
            return customers;
        }

        // Adds new customers to the repository and saves the data to the JSON file.
        public void AddCustomers(IEnumerable<Customer> newCustomers)
        {
            try{
                foreach (var customer in newCustomers)
                {   
                    // Validate the customer data before adding.
                    if (ValidateCustomer(customer))
                    {   
                        // Insert the new customer into the sorted list (not used sort())
                        InsertSorted(customer);
                    }
                    else{
                        // Throw an exception if the customer data is invalid.
                        throw new InvalidOperationException("Something wrong in Customer ID field");
                    }
                }

                SaveData();
            }
            catch (InvalidOperationException){
                // Re-throw the exception if validation or insertion fails.
                throw;
            }
            
        }

        // Validates the customer data.
        private bool ValidateCustomer(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.FirstName) ||
                string.IsNullOrEmpty(customer.LastName) ||
                customer.Age <= 18 || customer.Age > 90 ||
                customers.Any(c => c.Id == customer.Id))
            {
                return false;
            }
            return true;
        }

        // Inserts a new customer into the sorted list based on last name and first name.
        private void InsertSorted(Customer newCustomer)
        {
            int index = 0;
            while (index < customers.Count && string.Compare(newCustomer.LastName, customers[index].LastName, StringComparison.Ordinal) > 0)
            {
                index++;
            }

            while (index < customers.Count && string.Compare(newCustomer.LastName, customers[index].LastName, StringComparison.Ordinal) == 0 && string.Compare(newCustomer.FirstName, customers[index].FirstName, StringComparison.Ordinal) > 0)
            {
                index++;
            }

            customers.Insert(index, newCustomer);
        }

        // Loads customer data from the JSON file.
        private void LoadData()
        {
            if (File.Exists(dataFilePath))
            {
                var data = File.ReadAllText(dataFilePath);
                customers.AddRange(JsonConvert.DeserializeObject<List<Customer>>(data));
            }
        }

        // Saves customer data to the JSON file.
        private void SaveData()
        {
            var data = JsonConvert.SerializeObject(customers);
            File.WriteAllText(dataFilePath, data);
        }
    }
}