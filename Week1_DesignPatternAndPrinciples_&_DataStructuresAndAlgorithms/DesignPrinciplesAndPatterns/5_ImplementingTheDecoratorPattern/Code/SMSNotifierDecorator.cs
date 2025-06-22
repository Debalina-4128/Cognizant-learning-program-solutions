using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SMSNotifierDecorator: NotifierDecorator
{
    public SMSNotifierDecorator(Notifier notifier) : base(notifier)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        SendSMS(message);
    }

    private void SendSMS(string message)
    {
        Console.WriteLine("SMS Notification: " + message);
    }
}