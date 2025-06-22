using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    public void TestSingletonInstance()
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        if (Object.ReferenceEquals(logger1, logger2))
        {
            Console.WriteLine("Test Passed: Both refer to same instance");
        }
        else
        {
            Console.WriteLine("Test failed: Both are different instances");
        }
    }
}