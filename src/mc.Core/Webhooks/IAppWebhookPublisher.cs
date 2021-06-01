using System.Threading.Tasks;
using mc.Authorization.Users;

namespace mc.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
