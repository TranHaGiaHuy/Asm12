using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Customer_Service.Models;

namespace Assignment1WebClient.Controllers
{
    public class CustomersController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";

        public CustomersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "http://localhost:4000/apigateway/CustomerService";
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Customer customer)
        {
            Console.WriteLine("Da vo");
            if (ModelState.IsValid)
            {
                return View(customer);
            }
            var loginData = new { Username = customer.Username, Password = customer.Password };
            var jsonContent = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"{ProductApiUrl}/login", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Customers");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }
            return View(customer);
        }





        // GET: Customers
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage respone = await client.GetAsync(ProductApiUrl);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Customer> listProducts = JsonSerializer.Deserialize<List<Customer>>(strData, options);
            return View(listProducts);
        }
        // GET: Customers/Details/5
        public async Task<IActionResult> Details(string username)
        {
            Console.WriteLine($"Calling API: {ProductApiUrl}/{username}");
            HttpResponseMessage response = await client.GetAsync($"{ProductApiUrl}/{username}");
            if (response.IsSuccessStatusCode)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                Console.WriteLine(strData); 
                try
                {
                    Customer customer = JsonSerializer.Deserialize<Customer>(strData, options);
                    return View(customer);
                }
                catch (JsonException ex)
                {
                    // Handle deserialization error
                    Console.WriteLine(ex.Message);
                    return BadRequest("Error deserializing data.");
                }
            }
            return NotFound();
        }


        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {

            if (ModelState.IsValid)
            {
                var check = await client.GetAsync($"{ProductApiUrl}/{customer.Username}");

                if (check.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("Username", "Username already exists.");
                    return View(customer);
                }
                var jsonContent = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ProductApiUrl, jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(string username)
        {
            HttpResponseMessage response = await client.GetAsync($"{ProductApiUrl}/{username}");
            if (response.IsSuccessStatusCode)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                Customer customer = JsonSerializer.Deserialize<Customer>(strData, options);
                return View(customer);
            }
            return NotFound();
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string username, Customer customer)
        {
            if (username != customer.Username)
            {
                return NotFound();
            }
            Console.WriteLine("Hello");
           
                Console.WriteLine("Hello2");
            customer.Password="1";
                var jsonContent = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"{ProductApiUrl}/{username}", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Hello3");

                    return RedirectToAction(nameof(Index));
                }
            
            Console.WriteLine("Hello4");

            return View();
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(List<string> selectedUsernames)
        {
            if (selectedUsernames == null || !selectedUsernames.Any())
            {
                TempData["Message"] = "No customers selected.";
                return RedirectToAction(nameof(Index));
            }
            List<Customer> customerList = new List<Customer>();
            customerList = GetCustomersByUsernamesAsync(selectedUsernames);
            return View(customerList);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMultiple(List<string> selectedUsernames)
        {

            foreach (var username in selectedUsernames)
            {
                var response = await client.DeleteAsync($"{ProductApiUrl}/{username}");
                if (!response.IsSuccessStatusCode)
                {
                    return BadRequest(response);
                }
            }
            TempData["Message"] = "Customers deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

        public List<Customer> GetCustomersByUsernamesAsync(List<string> usernames)
        {
            var customers = new List<Customer>();

            foreach (var username in usernames)
            {
                HttpResponseMessage response = client.GetAsync($"{ProductApiUrl}/{username}").GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    string strData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    Customer customer = JsonSerializer.Deserialize<Customer>(strData, options);
                    if (customer != null)
                    {
                        customers.Add(customer);
                    }
                }
                else
                {
                    Console.WriteLine($"User {username} not found.");
                }
            }

            return customers;
        }

    }
}
