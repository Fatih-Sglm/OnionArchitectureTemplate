using MimeKit;

namespace Application.Commons.Models.EmailModels
{
    public class Mail
    {
        public string Subject { get; private set; }
        public string TextBody { get; private set; }
        public string HtmlBody { get; private set; }
        public AttachmentCollection? Attachments { get; private set; }
        public List<MailboxAddress> ToList { get; private set; }
        public List<MailboxAddress>? CcList { get; private set; }
        public List<MailboxAddress>? BccList { get; private set; }
        public string? UnscribeLink { get; private set; }
        public Mail(string subject, string textBody, string htmlBody, AttachmentCollection? attachments, List<MailboxAddress> toList,
                    List<MailboxAddress>? ccList = null, List<MailboxAddress>? bccList = null, string? unscribeLink = null)
        {
            Subject = subject;
            TextBody = textBody;
            HtmlBody = htmlBody;
            Attachments = attachments;
            ToList = toList;
            CcList = ccList;
            BccList = bccList;
            UnscribeLink = unscribeLink;
        }
    }
}
