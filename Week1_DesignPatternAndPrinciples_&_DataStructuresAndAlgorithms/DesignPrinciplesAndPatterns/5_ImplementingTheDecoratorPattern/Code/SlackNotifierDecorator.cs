using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SlackNotifierDecorator : NotifierDecorator
{
    public SlackNotifierDecorator(Notifier notifier) : base(notifier)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        SendSlack(message);
    }

    private void SendSlack(string message)
    {
        Console.WriteLine("Slack Notification: " + message);
    }
}