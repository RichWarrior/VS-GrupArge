using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailServie
{
    class Program
    {
        static void Main(string[] args)
        {
            MailMessage message = new MailMessage();
            message.Subject = "Mail Service Test";
            message.From = new MailAddress("sender");
            message.Body = "Mail Service Test";
            message.To.Add("receiver");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Credentials = new NetworkCredential("mail", "password");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Send(message);
            Console.ReadKey();
        }
    }
}
