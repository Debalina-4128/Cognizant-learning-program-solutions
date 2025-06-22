using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StockMarket : Stock
{
    private List<Observer> _observers = new List<Observer>();
    private string _stockName;
    private double _stockPrice;

    public StockMarket(string stockName, double stockPrice)
    {
        _stockName = stockName;
        _stockPrice = stockPrice;
    }

    public void Register(Observer observer)
    {
        _observers.Add(observer);
        Console.WriteLine(observer.GetType().Name + " registered to " + _stockName);
    }

    public void Deregister(Observer observer)
    {
        _observers.Remove(observer);
        Console.WriteLine(observer.GetType().Name + " deregistered from " + _stockName);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_stockName, _stockPrice);
        }
    }

    public void SetStockPrice(double price)
    {
        Console.WriteLine($"\n{_stockName} stock price updated to {price}");
        _stockPrice = price;
        NotifyObservers();
    }
}

