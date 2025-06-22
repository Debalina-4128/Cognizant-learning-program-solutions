using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface CustomerRepository
{
    Customer FindCustomerById(int id);
}