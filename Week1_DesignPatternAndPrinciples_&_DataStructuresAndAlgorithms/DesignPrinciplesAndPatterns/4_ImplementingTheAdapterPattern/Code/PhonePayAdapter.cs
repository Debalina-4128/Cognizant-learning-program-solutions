using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PhonePayAdapter : PaymentProcessor
{
    private PhonePayPaymentGateway _phonepay;

    public PhonePayAdapter(PhonePayPaymentGateway phonepay)
    {
        _phonepay = phonepay;
    }

    public void ProcessPayment(string amount)
    {
        _phonepay.SendPayment(amount);
    }
}