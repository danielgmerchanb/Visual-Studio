using System;
using System.Text;
using System.Net.Mail;
using SendEMail.Properties;

namespace SendEMail
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 8)
            {
                MessageInfo messageInfo = new MessageInfo
                {
                    FromAddress = args[0],
                    FromDisplay = args[1],
                    To = args[2].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries),
                    Cc = args[3].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries),
                    Bcc = args[4].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries),
                    Priority = args[5],
                    Subject = args[6],
                    Body = args[7]
                };

                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress(messageInfo.FromAddress, messageInfo.FromDisplay, UnicodeEncoding.Unicode);

                foreach (string to in messageInfo.To)
                    mailMessage.To.Add(to);
                foreach (string cc in messageInfo.Cc)
                    mailMessage.To.Add(cc);
                foreach (string bcc in messageInfo.Bcc)
                    mailMessage.To.Add(bcc);
                switch (messageInfo.Priority)
                {
                    case "High": mailMessage.Priority = MailPriority.High;
                        break;
                    case "Low": mailMessage.Priority = MailPriority.Low;
                        break;
                    default: mailMessage.Priority = MailPriority.Normal;
                        break;
                }
                mailMessage.Subject = messageInfo.Subject;
                mailMessage.Body = messageInfo.Body + Settings.Default.Signature;


                using (SmtpClient smtp = new System.Net.Mail.SmtpClient(Settings.Default.Host))
                {
                    try
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential(Settings.Default.UserName, Settings.Default.Password);
                        smtp.EnableSsl = true;
                        smtp.Port = Convert.ToInt32(Settings.Default.Port);
                        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

                        smtp.Send(mailMessage);
                    }
                    catch (SmtpException smtpException)
                    {
                        Console.WriteLine("Se produjo un error al enviar el correo.");
                        Console.WriteLine();
                        Console.WriteLine("Mensaje de Error");
                        Console.WriteLine("----------------");
                        Console.WriteLine(smtpException.Message);
                        Console.WriteLine();
                        Console.WriteLine("Pila de Llamados");
                        Console.WriteLine("----------------");
                        Console.WriteLine(smtpException.StackTrace);
                    }
                }
            }
            else
                Console.WriteLine("Se requieren los siguientes parametros: \"FromAddress\" \"FromDisplay\" \"To,To\" \"Cc,Cc\" \"Bcc,Bcc\" \"High|Low|Normal\" \"Subject\" \"Body\".");
        }
    }
}
