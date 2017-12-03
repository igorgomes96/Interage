using InterageApp.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;
using InterageApp.Models;
using InterageApp.Services.Interfaces;

namespace InterageApp.Services.Implementations
{
    public class EmailService : IEmailService
    {

        public void Send(object obj)
        {
            EmailDto email = (EmailDto)obj;

            string contaEmail = "interageapp@gmail.com";
            string senhaEmail = "interageapp2018";

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("Smtp.Gmail.com");

            mail.From = new MailAddress(contaEmail);
            foreach (string to in email.To.Where(x => x != "").Distinct())
                mail.To.Add(to);

            foreach (string copy in email.Copy.Where(x => x != "").Distinct())
                mail.CC.Add(copy);

            foreach (string bcc in email.Bcc.Where(x => x != "").Distinct())
                mail.Bcc.Add(bcc);

            mail.Subject = email.Subject;
            mail.IsBodyHtml = true;
            mail.Body = email.Message;

            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(contaEmail, senhaEmail);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

    }
}