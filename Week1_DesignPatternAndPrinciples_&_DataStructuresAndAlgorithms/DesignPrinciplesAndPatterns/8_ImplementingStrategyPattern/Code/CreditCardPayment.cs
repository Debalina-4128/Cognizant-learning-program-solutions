using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CreditCardPayment : PaymentStrategy
{
    public void Pay(string amount)
    {
        Console.WriteLine($"Paid {amount} using Credit Card.");
    }
}