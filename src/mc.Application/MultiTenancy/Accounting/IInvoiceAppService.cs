using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using mc.MultiTenancy.Accounting.Dto;

namespace mc.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
