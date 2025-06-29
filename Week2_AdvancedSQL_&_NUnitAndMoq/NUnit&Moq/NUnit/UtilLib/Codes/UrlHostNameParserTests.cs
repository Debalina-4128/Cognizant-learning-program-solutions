using NUnit.Framework;
using UtilLib;
using System;

namespace UtilLib.Tests
{
    [TestFixture]
    public class UrlHostNameParserTests
    {
        private UrlHostNameParser parser;

        [SetUp]
        public void SetUp()
        {
            parser = new UrlHostNameParser();
        }

        [Test]
        public void ParseHostName_ValidHttpUrl_ReturnsHostName()
        {
            var url = "http://www.example.com/page";

            var result = parser.ParseHostName(url);

            Assert.That(result, Is.EqualTo("www.example.com"));
        }

        [Test]
        public void ParseHostName_InvalidProtocol_ThrowsFormatException()
        {
            var url = "ftp://fileserver.com/folder";

            var ex = Assert.Throws<FormatException>(() => parser.ParseHostName(url));
            Assert.That(ex.Message, Is.EqualTo("Url is not in correct format"));
        }

        [Test]
        public void ParseHostName_EmptyUrl_ThrowsFormatException()
        {
            var url = "";

            var ex = Assert.Throws<FormatException>(() => parser.ParseHostName(url));
            Assert.That(ex.Message, Is.EqualTo("Url is not in correct format"));
        }
    }
}
