using System.Threading.Tasks;
using mc.Sessions.Dto;

namespace mc.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
