using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        PaymentProcessor gpayProcessor = new GPayAdapter(new GPayPaymentGateway());
        gpayProcessor.ProcessPayment("$9000");

        PaymentProcessor phonepayProcessor = new PhonePayAdapter(new PhonePayPaymentGateway());
        phonepayProcessor.ProcessPayment("$50000");
    }
}
