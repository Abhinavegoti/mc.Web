using System.Threading.Tasks;
using Abp.Dependency;

namespace mc.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}