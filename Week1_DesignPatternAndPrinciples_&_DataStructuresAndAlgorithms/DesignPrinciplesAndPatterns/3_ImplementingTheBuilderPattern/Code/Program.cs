using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Computer personalComputer = new Computer.Builder()
            .SetCPU("Intel i9")
            .SetRAM("32GB")
            .SetStorage("1TB SSD")
            .Build();
        Console.WriteLine("Personal Computer Configuration:");
        Console.WriteLine("CPU: " + personalComputer.CPU);
        Console.WriteLine("RAM: " + personalComputer.RAM);
        Console.WriteLine("Storage: " + personalComputer.Storage);
        Console.WriteLine();


        Computer officeComputer = new Computer.Builder()
            .SetCPU("Intel i5")
            .SetRAM("16GB")
            .SetStorage("512GB SSD")
            .Build();

        Console.WriteLine("Office Computer Configuration:");
        Console.WriteLine("CPU: " + officeComputer.CPU);
        Console.WriteLine("RAM:" + officeComputer.RAM);
        Console.WriteLine("Storage: " + officeComputer.Storage);
        Console.WriteLine();
    }
}
