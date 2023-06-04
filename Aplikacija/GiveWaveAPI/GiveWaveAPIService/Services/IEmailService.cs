
using GiveWaveApiService.Models;

namespace GiveWaveApiService.Services
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
