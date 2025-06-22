using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CustomerService
{
    private CustomerRepository _customerRepository;

    // Constructor Injection
    public CustomerService(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void GetCustomerDetails(int id)
    {
        Customer customer = _customerRepository.FindCustomerById(id);
        if (customer != null)
        {
            Console.WriteLine($"Customer Found: {customer.Name}, {customer.Email}");
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
    }
}