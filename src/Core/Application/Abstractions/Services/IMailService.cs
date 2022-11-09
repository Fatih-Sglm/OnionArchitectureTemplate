using Application.Commons.Models.EmailModels;

namespace Application.Abstractions.Services
{
    public interface IMailService
    {
        void SendMail(Mail mail);
    }
}
