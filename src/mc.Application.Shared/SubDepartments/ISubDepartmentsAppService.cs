using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using mc.SubDepartments.Dtos;
using mc.Dto;
using System.Collections.Generic;

namespace mc.SubDepartments
{
    public interface ISubDepartmentsAppService : IApplicationService
    {
        Task<PagedResultDto<GetSubDepartmentForViewDto>> GetAll(GetAllSubDepartmentsInput input);

        Task<GetSubDepartmentForViewDto> GetSubDepartmentForView(int id);

        Task<GetSubDepartmentForEditOutput> GetSubDepartmentForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditSubDepartmentDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetSubDepartmentsToExcel(GetAllSubDepartmentsForExcelInput input);

        Task<List<SubDepartmentDepartmentLookupTableDto>> GetAllDepartmentForTableDropdown();

    }
}