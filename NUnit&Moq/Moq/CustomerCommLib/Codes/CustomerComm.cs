namespace CustomerCommLib
{
    public class CustomerComm
    {
        private readonly IMailSender _mailSender;

        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            // Simulated mail details
            return _mailSender.SendMail("cust123@abc.com", "Some Message");
        }
    }
}
