using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using mc.EmployeeInformationMasters.Dtos;
using mc.Dto;

namespace mc.EmployeeInformationMasters
{
    public interface IEmployeeInformationMastersAppService : IApplicationService
    {
        Task<PagedResultDto<GetEmployeeInformationMasterForViewDto>> GetAll(GetAllEmployeeInformationMastersInput input);

        Task<GetEmployeeInformationMasterForViewDto> GetEmployeeInformationMasterForView(int id);

        Task<GetEmployeeInformationMasterForEditOutput> GetEmployeeInformationMasterForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditEmployeeInformationMasterDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetEmployeeInformationMastersToExcel(GetAllEmployeeInformationMastersForExcelInput input);

    }
}