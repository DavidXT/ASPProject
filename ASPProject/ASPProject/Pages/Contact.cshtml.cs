using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;

namespace ASPProject.Pages
{
    public class ContactModel : PageModel
    {
        public void OnPost()
        {
            string email = Request.Form["email"];
            string subject = Request.Form["subject"];
            string body = Request.Form["body"];

            SendMail(email, subject, body);
        }

        private void SendMail(string email, string subject, string body)
        {
            
            string fromMail = "david.xt.nguyen@gmail.com";
            string fromPassword = "hrxwuexikufjscwo";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = body;
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }
    }
}
