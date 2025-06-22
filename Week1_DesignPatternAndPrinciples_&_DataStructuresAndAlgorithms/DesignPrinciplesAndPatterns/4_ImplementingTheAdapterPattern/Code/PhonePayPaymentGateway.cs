using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PhonePayPaymentGateway
{
    public void SendPayment(string amount)
    {
        Console.WriteLine("Payment of " + amount + " processed");
    }
}
