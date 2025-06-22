using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Notifier emailNotifier = new EmailNotifier();
        Notifier smsNotifier = new SMSNotifierDecorator(emailNotifier);
        Notifier slackNotifier = new SlackNotifierDecorator(smsNotifier);

        slackNotifier.Send("Your task has been completed");

        Console.WriteLine();

        Notifier emailSmsNotifier = new SMSNotifierDecorator(emailNotifier);
        emailSmsNotifier.Send("Your order has been shipped");
    }
}
