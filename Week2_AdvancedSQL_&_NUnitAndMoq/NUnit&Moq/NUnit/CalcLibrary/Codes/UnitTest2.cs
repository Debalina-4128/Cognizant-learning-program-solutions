using CalcLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalcLibrary2.Tests
{
    [TestClass]
    public class SimpleCalculatorTests
    {
        private SimpleCalculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [TestCleanup]
        public void Teardown()
        {
            calculator.AllClear();
        }

        [DataTestMethod]
        [DataRow(5, 3, 2)]
        [DataRow(3, 5, -2)]
        [DataRow(-4, -2, -2)]
        [DataRow(0, 0, 0)]
        public void Subtraction_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Subtraction(a, b);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(2, 3, 6)]
        [DataRow(0, 100, 0)]
        [DataRow(-5, 2, -10)]
        [DataRow(-3, -4, 12)]
        public void Multiplication_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Multiplication(a, b);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(10, 2, 5)]
        [DataRow(7.5, 2.5, 3)]
        [DataRow(-9, 3, -3)]
        public void Division_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Division(a, b);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Division_ByZero_ShouldThrowException()
        {
            try
            {
                calculator.Division(10, 0);
                Assert.Fail("Division by zero"); // If no exception, this line will fail the test
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Second Parameter Can't be Zero", ex.Message);
            }
        }

        [TestMethod]
        public void TestAddAndClear()
        {
            var result = calculator.Addition(4, 6);
            Assert.AreEqual(10, result);
            Assert.AreEqual(10, calculator.GetResult);

            calculator.AllClear();
            Assert.AreEqual(0, calculator.GetResult);
        }
    }
}

