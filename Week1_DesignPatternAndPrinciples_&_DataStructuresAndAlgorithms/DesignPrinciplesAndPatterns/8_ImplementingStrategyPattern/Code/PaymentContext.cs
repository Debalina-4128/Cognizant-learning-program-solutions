using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PaymentContext
{
    private PaymentStrategy _paymentStrategy;

    public void SetPaymentStrategy(PaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void Pay(string amount)
    {
        if (_paymentStrategy == null)
        {
            Console.WriteLine("Please select a payment method.");
            return;
        }
        _paymentStrategy.Pay(amount);
    }
}