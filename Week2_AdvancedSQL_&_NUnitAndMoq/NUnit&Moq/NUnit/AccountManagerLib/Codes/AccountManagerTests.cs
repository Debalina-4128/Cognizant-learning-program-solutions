using NUnit.Framework;
using AccountsManagerLib;
using System;

namespace AccountsManagerLib.Tests
{
    [TestFixture]
    public class AccountsManagerTests
    {
        private AccountsManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new AccountsManager();
        }

        [Test]
        public void ValidateUser_ValidUser11_ReturnsWelcomeMessage()
        {
            var result = manager.ValidateUser("user_11", "secret@user11");
            Assert.That(result, Is.EqualTo("Welcome user_11!!!"));
        }

        [Test]
        public void ValidateUser_ValidUser22_ReturnsWelcomeMessage()
        {
            var result = manager.ValidateUser("user_22", "secret@user22");
            Assert.That(result, Is.EqualTo("Welcome user_22!!!"));
        }

        [Test]
        public void ValidateUser_InvalidCredentials_ReturnsInvalidMessage()
        {
            var result = manager.ValidateUser("user_11", "wrongpass");
            Assert.That(result, Is.EqualTo("Invalid user id/password"));
        }

        [Test]
        public void ValidateUser_EmptyUserId_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() => manager.ValidateUser("", "secret@user11"));
            Assert.That(ex.Message, Is.EqualTo("Both user id and password are mandatory"));
        }

        [Test]
        public void ValidateUser_EmptyPassword_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() => manager.ValidateUser("user_11", ""));
            Assert.That(ex.Message, Is.EqualTo("Both user id and password are mandatory"));
        }

        [Test]
        public void ValidateUser_NullCredentials_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() => manager.ValidateUser(null, null));
            Assert.That(ex.Message, Is.EqualTo("Both user id and password are mandatory"));
        }
    }
}
