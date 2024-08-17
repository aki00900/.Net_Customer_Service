using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CustomerManagementSimulator
{
    // Define a Customer class to represent customer data.
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var BASEURI = "http://localhost:5102"; 

            // Simulate POST requests by generating random customer data from the given Data Set.
            for (int i = 1; i <= 5; i++)
            {
                var customers = GenerateRandomCustomers(2, i);
                var json = JsonConvert.SerializeObject(customers);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"{BASEURI}/customer", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"POST Request {i} Response: {responseContent}");
            }

            // Simulate a GET request to retrieve customer data.
            var getResponse = await httpClient.GetStringAsync($"{BASEURI}/customer");
            var customersList = JsonConvert.DeserializeObject<Customer[]>(getResponse);
            Console.WriteLine("GET Request Response:");
            foreach (var customer in customersList)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.FirstName} {customer.LastName}, Age: {customer.Age}");
            }
        }

        // Generate an array of random Customer objects with sequential ID's.
        static Customer[] GenerateRandomCustomers(int count, int offset)
        {
            var customers = new Customer[count];
            var rand = new Random();

            for (int i = 0; i < count; i++)
            {
                customers[i] = new Customer
                {
                    FirstName = GetRandomFirstName(rand),
                    LastName = GetRandomLastName(rand),
                    Age = rand.Next(10, 90),
                    Id = (offset * 10) + i
                };
               
            }
            
            for (int i = 0; i < customers.Count(); i++)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine(customers[i].FirstName);
                Console.WriteLine(customers[i].LastName);
                Console.WriteLine(customers[i].Age);
                Console.WriteLine(customers[i].Id);
            }

            return customers;
        }

        // Get a random first name from a predefined list.
        static string GetRandomFirstName(Random rand)
        {
            string[] firstNames = { "Leia", "Sadie", "Jose", "Sara", "Frank", "Dewey", "Tomas", "Joel", "Lukas", "Carlos" };
            return firstNames[rand.Next(firstNames.Length)];
        }

        // Get a random last name from a predefined list.
        static string GetRandomLastName(Random rand)
        {
            string[] lastNames = { "Liberty", "Ray", "Harrison", "Ronan", "Drew", "Powell", "Larsen", "Chan", "Anderson", "Lane" };
            return lastNames[rand.Next(lastNames.Length)];
        }
    }
}
