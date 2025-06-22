using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GPayAdapter : PaymentProcessor
{
    private GPayPaymentGateway _gpay;

    public GPayAdapter(GPayPaymentGateway gpay)
    {
        _gpay = gpay;
    }

    public void ProcessPayment(string amount)
    {
        _gpay.MakePayment(amount);
    }
}