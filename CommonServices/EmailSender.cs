using System.Net;
using System.Net.Mail;

namespace Medical_Athena_Calendly.CommonServices
{
    public class EmailSender
    {
        private IConfiguration _configuration;


        public EmailSender(IConfiguration configuration1)
        {

            _configuration = configuration1;
        }


        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var smtpHost = _configuration.GetValue<string>("MailSettings:Host");
                var smtpPort = _configuration.GetValue<int>("MailSettings:Port");
                var smtpUsername = _configuration.GetValue<string>("MailSettings:Mail");
                var smtpPassword = _configuration.GetValue<string>("MailSettings:Password");


                using var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpUsername),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(new MailAddress(toEmail));

                using var smtpClient = new SmtpClient(smtpHost, smtpPort)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                    EnableSsl = false
                };

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // Handle email sending failure here (e.g., log the error)
                return false;
            }
        }
    }
}
