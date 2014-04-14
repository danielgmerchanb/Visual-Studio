
namespace SendEMail
{
    public class MessageInfo
    {
        public string FromAddress { get; set; }

        public string FromDisplay { get; set; }

        public string[] To { get; set; }

        public string[] Cc { get; set; }

        public string[] Bcc { get; set; }

        public string Priority { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
