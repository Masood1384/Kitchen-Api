using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.Tools.Emailsender
{
    public class EmailSenderService : IEmailSenderService
    {
        public async Task SendEmail(string To, string Subject, string Body)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Kitchen", "Masood-tmp.ir"));
            mimeMessage.To.Add(new MailboxAddress(To, To));
            mimeMessage.Subject = Subject;
            mimeMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = Body
            };
            using var Client = new SmtpClient();
            await Client.ConnectAsync("smtp.gmail.com", 465, true).ConfigureAwait(false);
            await Client.AuthenticateAsync("masood.tmp84@gmail.com", "dqznvrqryhdyoxoy").ConfigureAwait(false);
            await Client.SendAsync(mimeMessage).ConfigureAwait(false);
            await Client.DisconnectAsync(true).ConfigureAwait(false);

        }
    }
}
