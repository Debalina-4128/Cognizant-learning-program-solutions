using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RealImage : Image
{
    private string _fileName;

    public RealImage(string fileName)
    {
        _fileName = fileName;
        LoadFromDisk();
    }

    private void LoadFromDisk()
    {
        Console.WriteLine("Loading image from disk: " + _fileName);
    }

    public void Display()
    {
        Console.WriteLine("Displaying image: " + _fileName);
    }
}
