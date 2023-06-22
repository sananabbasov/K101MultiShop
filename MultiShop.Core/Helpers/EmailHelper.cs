using System;
using System.Net;
using System.Net.Mail;

namespace MultiShop.Core.Helpers
{
    public class EmailHelper
    {


        public void SendConfirmationEmail(string email, string token, string name, string surname)
        {

            SmtpClient smtpClient = new("smtp.ethereal.email", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("ronny.hane@ethereal.email", "AXgAkv6EjzN5QRfqPN");

            try
            {
                MailMessage mailMessage = new();
                mailMessage.From = new MailAddress("ronny.hane@ethereal.email");
                mailMessage.To.Add("ronny.hane@ethereal.email");
                mailMessage.Subject = "Confirm email";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = $"Confirm your email <a href='https://localhost:7104/auth/confirmemail?token={token}&email={email}'>Click here</a>";
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {

            }

        }
    }
}

