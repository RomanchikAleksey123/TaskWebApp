﻿using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using WebApplication.Contracts;

namespace WebApplication.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Site administration", "romanchikkotik@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 465, true);
            await client.AuthenticateAsync("romanchikkotik@gmail.com", "Alex_2015");
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }
    }
}
