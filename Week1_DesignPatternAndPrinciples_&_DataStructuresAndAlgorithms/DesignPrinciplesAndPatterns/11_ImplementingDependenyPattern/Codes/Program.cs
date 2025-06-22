using System;

class Program
{
    static void Main(string[] args)
    {
        CustomerRepository customerRepository = new CustomerRepositoryImpl();

        CustomerService customerService = new CustomerService(customerRepository);

        customerService.GetCustomerDetails(1);
        customerService.GetCustomerDetails(3); // ID not in data
    }
}