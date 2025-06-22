using System;
class FutureValueCalculator
{
    public static double CalculateFutureValue(double presentValue, double growthRate, int years)
    {
        if (years == 0)
            return presentValue;

        return CalculateFutureValue(presentValue, growthRate, years - 1) * (1 + growthRate);
    }

    public static double CalculateFutureValueOptimized(double presentValue, double growthRate, int years)
    {
        return presentValue * Math.Pow(1 + growthRate, years);
    }

    static void Main(string[] args)
    {
        double presentValue = 1000;
        double growthRate = 0.05;   
        int years = 5;

        double futureValue = CalculateFutureValue(presentValue, growthRate, years);
        Console.WriteLine($"Future Value (Recursive): {futureValue:F2}");

        double futureValueOptimized = CalculateFutureValueOptimized(presentValue, growthRate, years);
        Console.WriteLine($"Future Value (Optimized): {futureValueOptimized:F2}");
    }
}