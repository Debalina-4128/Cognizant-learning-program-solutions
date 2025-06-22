using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustomerRepositoryImpl : CustomerRepository
{
    private Dictionary<int, Customer> _customerData = new Dictionary<int, Customer>()
    {
        { 1, new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" } },
        { 2, new Customer { Id = 2, Name = "Jane Smith", Email = "jane@example.com" } }
    };

    public Customer FindCustomerById(int id)
    {
        if (_customerData.ContainsKey(id))
        {
            return _customerData[id];
        }
        else
        {
            return null;
        }
    }
}
