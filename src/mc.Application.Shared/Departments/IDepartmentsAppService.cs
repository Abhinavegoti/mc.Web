﻿using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using mc.Departments.Dtos;
using mc.Dto;

namespace mc.Departments
{
    public interface IDepartmentsAppService : IApplicationService
    {
        Task<PagedResultDto<GetDepartmentForViewDto>> GetAll(GetAllDepartmentsInput input);

        Task<GetDepartmentForViewDto> GetDepartmentForView(int id);

        Task<GetDepartmentForEditOutput> GetDepartmentForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditDepartmentDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetDepartmentsToExcel(GetAllDepartmentsForExcelInput input);

    }
}