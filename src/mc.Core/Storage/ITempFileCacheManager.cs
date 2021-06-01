using Abp.Dependency;

namespace mc.Storage
{
    public interface ITempFileCacheManager: ITransientDependency
    {
        void SetFile(string token, byte[] content);

        byte[] GetFile(string token);
    }
}
