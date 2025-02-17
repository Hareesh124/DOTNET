using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace FileCheck
{
    public partial class Mail : System.Web.UI.Page
    {
        public void Page()
        {
            string folderPath = @"C:\Training\test";
            string fileName = "test.txt";

            string filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
            {
                string recipientEmail = "hareesh@outlook.com"; 
                string subject = "File Found";
                string body = $"The file '{fileName}' is present in the folder '{folderPath}'.";

                SendEmailNotification(recipientEmail, subject, body);
                Response.Write("The file is found, and an email has been sent.");
            }
            else
            {
                Response.Write("The file is not found in the specified folder.");
            }
        }

        private void SendEmailNotification(string recipientEmail, string subject, string body)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("hareesh@outlook.com", "123pass"),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("hareesh@outlook.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(recipientEmail);

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Response.Write($"Error sending email: {ex.Message}");
            }
        }
    }
}
