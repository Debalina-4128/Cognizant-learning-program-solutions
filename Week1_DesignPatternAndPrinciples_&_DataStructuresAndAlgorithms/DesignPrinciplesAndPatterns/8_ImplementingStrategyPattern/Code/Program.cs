using System;

class Program
{
    static void Main(string[] args)
    {
        PaymentContext paymentContext = new PaymentContext();

        paymentContext.SetPaymentStrategy(new CreditCardPayment());
        paymentContext.Pay("$150");

        Console.WriteLine();

        paymentContext.SetPaymentStrategy(new PayPalPayment());
        paymentContext.Pay("$250");
    }
}