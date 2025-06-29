using NUnit.Framework;
using System;
using UserManagerLib;

namespace UserManagerLib.Tests
{
    [TestFixture]
    public class UserTests
    {
        private User _user;

        [SetUp]
        public void Setup()
        {
            _user = new User();
        }

        [Test]
        public void ValidatePANCardNumber_ValidLength_ReturnsValid()
        {
            string result = _user.ValidatePANCardNumber("ABCDE1234F");
            Assert.That(result, Is.EqualTo("Valid"));
        }

        [Test]
        public void ValidatePANCardNumber_EmptyPAN_ThrowsNullReferenceException()
        {
            var ex = Assert.Throws<NullReferenceException>(() =>
            {
                _user.ValidatePANCardNumber("");
            });

            Assert.That(ex.Message, Is.EqualTo("Invalid Pan Card Number"));
        }

        [Test]
        public void ValidatePANCardNumber_NullPAN_ThrowsNullReferenceException()
        {
            var ex = Assert.Throws<NullReferenceException>(() =>
            {
                _user.ValidatePANCardNumber(null);
            });

            Assert.That(ex.Message, Is.EqualTo("Invalid Pan Card Number"));
        }

        [Test]
        public void ValidatePANCardNumber_InvalidLengthPAN_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() =>
            {
                _user.ValidatePANCardNumber("ABCDE123");  // 9 characters
            });

            Assert.That(ex.Message, Is.EqualTo("Pan Card Number Should contain only 10 characters"));
        }

        [Test]
        public void CreateUser_ValidPANCard_CreatesUserSuccessfully()
        {
            var newUser = new User
            {
                FirstName = "John",
                LastName = "Doe",
                EmailId = "john@example.com",
                PANCardNo = "ABCDE1234F"
            };

            Assert.That(() => _user.CreateUser(newUser), Throws.Nothing);
        }
    }
}
