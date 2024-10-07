using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Customer_Service.Models;
using Microsoft.AspNetCore.Identity;

namespace Customer_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerDbContext _context;
        private readonly IPasswordHasher<Customer> _passwordHasher;
        public CustomersController(CustomerDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Customer>();
        }


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(string username, string password)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Username == username);

            if (customer == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            // Verify the password
            var result = _passwordHasher.VerifyHashedPassword(customer, customer.Password,password);
            if (result == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Return a success message or token
            return Ok("Login successful");
        }



        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            foreach (var customer in customers)
            {
                customer.Password = "";
            }
            return Ok(customers);
        }

        // GET: api/Customers/5
        [HttpGet("{username}")]
        public async Task<ActionResult<Customer>> GetCustomer(string username)
        {
            var customer = await _context.Customers.FindAsync(username);

            if (customer == null)
            {
                return NotFound();
            }
            customer.Password = "";
            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{username}")]
        public async Task<IActionResult> PutCustomer(string username, Customer customer)
        {
            if (username != customer.Username)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(username))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomer", new { username = customer.Username }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteCustomer(string username)
        {
            var customer = await _context.Customers.FindAsync(username);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(string username)
        {
            return _context.Customers.Any(e => e.Username == username);
        }
    }
}
