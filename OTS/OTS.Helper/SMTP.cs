using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OTS.Helper
{
    public class SMTP
    {
        public static void SendEmail(string to, string title, StringBuilder msg)
        {

            var email = new SendEmailThread();
            email.to = to;
            email.title = title;
            email.msg = msg;
            var workerThread = new Thread(email.SendEmail);
            workerThread.Start();
        }
        
        
    }
    class SendEmailThread
    {
        public string to;
        public StringBuilder msg;
        public string title;
        public void SendEmail()
        {
            try
            {
                string Email = ConfigurationManager.AppSettings["SMTP.Email"].ToString();
                string Pass = ConfigurationManager.AppSettings["SMTP.Pass"].ToString();
                var fromAddress = new MailAddress(Email, "MUM OTS");
                var toAddress = new MailAddress(to, to);
                string fromPassword = Pass;
                var subject = title;
                var body = msg;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {

                    Subject = subject,
                    Body = body.ToString()
                })
                {
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                }
                return;
            }
            catch (Exception)
            {
            }
        }
    }
}
