using NUnit.Framework;
using SeasonsLib;
using System.Collections.Generic;

namespace SeasonsLib.Tests
{
    [TestFixture]
    public class SeasonTellerTests
    {
        private SeasonTeller _teller;

        [SetUp]
        public void Setup()
        {
            _teller = new SeasonTeller();
        }

        [Test]
        [TestCase("February", "Spring")]
        [TestCase("April", "Summer")]
        [TestCase("July", "Monsoon")]
        [TestCase("October", "Autumn")]
        [TestCase("December", "Winter")]
        public void DisplaySeasonBy_ValidMonth_ReturnsCorrectSeason(string month, string expectedSeason)
        {
            string result = _teller.DisplaySeasonBy(month);
            Assert.That(result, Is.EqualTo(expectedSeason));
        }

        [Test]
        [TestCase("NotAMonth")]
        [TestCase("Hello")]
        [TestCase("")]
        //[TestCase(null)]
        public void DisplaySeasonBy_InvalidMonth_ReturnsInvalidSeason(string month)
        {
            string result = _teller.DisplaySeasonBy(month);
            Assert.That(result, Is.EqualTo("Invalid Season"));
        }

        private static readonly object[] AllMonthData =
        {
            new object[] { "February", "Spring" },
            new object[] { "March", "Spring" },
            new object[] { "April", "Summer" },
            new object[] { "May", "Summer" },
            new object[] { "June", "Summer" },
            new object[] { "July", "Monsoon" },
            new object[] { "August", "Monsoon" },
            new object[] { "September", "Monsoon" },
            new object[] { "October", "Autumn" },
            new object[] { "November", "Autumn" },
            new object[] { "December", "Winter" },
            new object[] { "January", "Winter" },
        };

        [Test, TestCaseSource(nameof(AllMonthData))]
        public void DisplaySeasonBy_CompleteMonthSet_MatchesExpectedSeason(string month, string expectedSeason)
        {
            var result = _teller.DisplaySeasonBy(month);
            Assert.That(result, Is.EqualTo(expectedSeason));
        }
    }
}
