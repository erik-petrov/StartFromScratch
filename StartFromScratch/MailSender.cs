using System.Net.Mail;
using System.Net;
using System.Text;

namespace StartFromScratch
{
    public static class MailSender
    {
        public static void SendEmail(string Subject, string Body, string recipient, DateTime start, DateTime end)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
            var mailMessage = new MailMessage
            {
                From = new MailAddress("testamogus123@hotmail.com"),
                Subject = Subject,
                Body = Body,
                IsBodyHtml = true,
            };
            mailMessage.Body = Body;
            using (FileStream fs = File.Create("mail.ics"))
            {
                byte[] text = new UTF8Encoding(true).GetBytes(CreateICS.CreateICSFile(start, end, "RealEstate buying",
                    "You've a meeting for a house lookup."));
                fs.Write(text, 0, text.Length);
            }
            mailMessage.Attachments.Add(new Attachment("mail.ics"));
            mailMessage.To.Add(recipient);
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new NetworkCredential("testamogus123@hotmail.com", "AmogusGaming228");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mailMessage);
            mailMessage.Dispose();
        }
    }
}
