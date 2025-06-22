using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WebApp : Observer
{
    public void Update(string stockName, double stockPrice)
    {
        Console.WriteLine($"Web App Notification: {stockName} price is now {stockPrice}");
    }
}