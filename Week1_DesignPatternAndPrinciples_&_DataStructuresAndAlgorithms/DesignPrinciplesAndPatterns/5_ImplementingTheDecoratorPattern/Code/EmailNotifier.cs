using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EmailNotifier : Notifier
{
    public void Send(string message)
    {
        Console.WriteLine("Email Notification: " + message);
    }
}