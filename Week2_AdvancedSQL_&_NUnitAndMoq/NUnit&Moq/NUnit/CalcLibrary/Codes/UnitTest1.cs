using System;
using CalcLibrary;
using NUnit.Framework;


namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            calculator.AllClear();
        }

        [Test]
        [TestCase(5,3,8)]
        [TestCase(-2, 4, 2)]
        [TestCase(0,0,0)]
        public void Addition_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        [TestCase(5, 3, 2)]
        [TestCase(0, 4, -4)]
        [TestCase(-3, -3, 0)]
        public void Subtraction_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 3, 6)]
        [TestCase(-2, 4, -8)]
        [TestCase(0, 10, 0)]
        public void Multiplication_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(10, 2, 5)]
        [TestCase(-9, 3, -3)]
        [TestCase(7.5, 2.5, 3)]
        public void Division_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            var result = calculator.Division(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ByZero_ShouldThrowException()
        {
            var ex = Assert.Throws<ArgumentException>(() => calculator.Division(5, 0));
            Assert.That(ex.Message, Is.EqualTo("Second Parameter Can't be Zero"));
        }

        [Test]
        public void AllClear_ShouldResetResultToZero()
        {
            calculator.Addition(10, 5);
            calculator.AllClear();
            Assert.That(calculator.GetResult, Is.EqualTo(0));
        }
    }
}
    

