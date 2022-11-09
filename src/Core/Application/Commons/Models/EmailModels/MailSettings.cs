namespace Application.Commons.Models.EmailModels
{
    public class MailSettings
    {
        public string Server { get; private set; }
        public int Port { get; private set; }
        public string SenderFullName { get; private set; }
        public string SenderEmail { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool AuthenticationRequired { get; private set; } = false;
        public string? DkimPrivateKey { get; private set; }
        public string? DkimSelector { get; private set; }
        public string? DomainName { get; private set; }

        public MailSettings(string server, int port, string senderFullName, string senderEmail, string userName,
                        string password, bool authenticationRequired = false, string? dkimPrivateKey = null, string? dkimSelector = null, string? domainName = null)
        {
            Server = server;
            Port = port;
            SenderFullName = senderFullName;
            SenderEmail = senderEmail;
            UserName = userName;
            Password = password;
            AuthenticationRequired = authenticationRequired;
            DkimPrivateKey = dkimPrivateKey;
            DkimSelector = dkimSelector;
            DomainName = domainName;
        }
    }
}
