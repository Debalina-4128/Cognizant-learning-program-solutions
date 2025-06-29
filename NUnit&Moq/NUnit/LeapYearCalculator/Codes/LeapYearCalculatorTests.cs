using NUnit.Framework;
using LeapYearCalculatorLib;

namespace LeapYearCalculatorLib.Tests
{
    [TestFixture]
    public class LeapYearCalculatorTests
    {
        private LeapYearCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new LeapYearCalculator();
        }

        // ✅ Valid leap year
        [Test]
        [TestCase(2000)]
        [TestCase(1996)]
        [TestCase(2400)]
        public void IsLeapYear_ValidLeapYear_Returns1(int year)
        {
            var result = calculator.IsLeapYear(year);
            Assert.That(result, Is.EqualTo(1));
        }

        // ✅ Valid non-leap year
        [Test]
        [TestCase(1900)]
        [TestCase(2019)]
        [TestCase(2023)]
        public void IsLeapYear_ValidNonLeapYear_Returns0(int year)
        {
            var result = calculator.IsLeapYear(year);
            Assert.That(result, Is.EqualTo(0));
        }

        // ✅ Invalid year below 1753
        [Test]
        [TestCase(1500)]
        [TestCase(1600)]
        public void IsLeapYear_YearLessThan1753_ReturnsMinus1(int year)
        {
            var result = calculator.IsLeapYear(year);
            Assert.That(result, Is.EqualTo(-1));
        }

        // ✅ Invalid year above 9999
        [Test]
        [TestCase(10000)]
        [TestCase(12000)]
        public void IsLeapYear_YearGreaterThan9999_ReturnsMinus1(int year)
        {
            var result = calculator.IsLeapYear(year);
            Assert.That(result, Is.EqualTo(-1));
        }

        // ✅ Boundary tests
        [Test]
        public void IsLeapYear_BoundaryYear1753_ValidRangeCheck()
        {
            var result = calculator.IsLeapYear(1753);
            Assert.That(result, Is.EqualTo(0)); // 1753 is not a leap year
        }

        [Test]
        public void IsLeapYear_BoundaryYear9999_ValidRangeCheck()
        {
            var result = calculator.IsLeapYear(9999);
            Assert.That(result, Is.EqualTo(0)); // 9999 is not a leap year
        }
    }
}
