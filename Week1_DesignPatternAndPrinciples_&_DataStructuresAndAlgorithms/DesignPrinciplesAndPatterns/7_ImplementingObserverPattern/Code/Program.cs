using System;

class Program
{
    static void Main(string[] args)
    {
        StockMarket appleStock = new StockMarket("Apple", 150.00);

        Observer mobileApp = new MobileApp();
        Observer webApp = new WebApp();

        appleStock.Register(mobileApp);
        appleStock.Register(webApp);

        appleStock.SetStockPrice(155.00);
        appleStock.SetStockPrice(160.50);

        appleStock.Deregister(mobileApp);

        appleStock.SetStockPrice(165.75);
    }
}