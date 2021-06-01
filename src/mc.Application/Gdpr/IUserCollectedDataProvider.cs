using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using mc.Dto;

namespace mc.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
