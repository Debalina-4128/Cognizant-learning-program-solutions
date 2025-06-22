using System;
using System.Diagnostics.CodeAnalysis;

public class Logger
{
    private static Logger instance;

    private Logger()
    {
        Console.WriteLine("Logger");
    }

    public static Logger GetInstance()
    {
        if(instance == null)
        {
            instance = new Logger();
        }
        return instance;
    }

    public void Log(String message)
    {
        Console.WriteLine("Log: " + message);
    }
}
