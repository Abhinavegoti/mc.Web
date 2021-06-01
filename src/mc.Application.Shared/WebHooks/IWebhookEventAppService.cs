using System.Threading.Tasks;
using Abp.Webhooks;

namespace mc.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
