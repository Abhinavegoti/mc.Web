using System.Threading.Tasks;

namespace mc.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}