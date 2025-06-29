using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommLib.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> mockMailSender;
        private CustomerComm customerComm;

        [OneTimeSetUp]
        public void Setup()
        {
            // Create mock object
            mockMailSender = new Mock<IMailSender>();

            // Setup: Any string parameters -> returns true
            mockMailSender.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                          .Returns(true);

            customerComm = new CustomerComm(mockMailSender.Object);
        }

        [Test]
        public void SendMailToCustomer_ValidCall_ReturnsTrue()
        {
            // Act
            var result = customerComm.SendMailToCustomer();

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
