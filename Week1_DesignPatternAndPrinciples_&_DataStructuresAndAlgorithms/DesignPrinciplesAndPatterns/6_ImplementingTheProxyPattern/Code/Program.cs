
using System;

class Program
{
    static void Main(string[] args)
    {
        Image image1 = new ProxyImage("photo1.jpg");
        Image image2 = new ProxyImage("photo2.jpg");

        
        image1.Display(); 
        image1.Display();

        Console.WriteLine();

        image2.Display(); 
        image2.Display();
    }
}
