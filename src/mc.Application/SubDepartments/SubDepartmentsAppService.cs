using mc.Departments;

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using mc.SubDepartments.Exporting;
using mc.SubDepartments.Dtos;
using mc.Dto;
using Abp.Application.Services.Dto;
using mc.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using mc.Storage;

namespace mc.SubDepartments
{
    [AbpAuthorize(AppPermissions.Pages_SubDepartments)]
    public class SubDepartmentsAppService : mcAppServiceBase, ISubDepartmentsAppService
    {
        private readonly IRepository<SubDepartment> _subDepartmentRepository;
        private readonly ISubDepartmentsExcelExporter _subDepartmentsExcelExporter;
        private readonly IRepository<Department, int> _lookup_departmentRepository;

        public SubDepartmentsAppService(IRepository<SubDepartment> subDepartmentRepository, ISubDepartmentsExcelExporter subDepartmentsExcelExporter, IRepository<Department, int> lookup_departmentRepository)
        {
            _subDepartmentRepository = subDepartmentRepository;
            _subDepartmentsExcelExporter = subDepartmentsExcelExporter;
            _lookup_departmentRepository = lookup_departmentRepository;

        }

        public async Task<PagedResultDto<GetSubDepartmentForViewDto>> GetAll(GetAllSubDepartmentsInput input)
        {

            var filteredSubDepartments = _subDepartmentRepository.GetAll()
                        .Include(e => e.NameFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.SubName.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubNameFilter), e => e.SubName == input.SubNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DepartmentNameFilter), e => e.NameFk != null && e.NameFk.Name == input.DepartmentNameFilter);

            var pagedAndFilteredSubDepartments = filteredSubDepartments
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var subDepartments = from o in pagedAndFilteredSubDepartments
                                 join o1 in _lookup_departmentRepository.GetAll() on o.Name equals o1.Id into j1
                                 from s1 in j1.DefaultIfEmpty()

                                 select new
                                 {

                                     o.SubName,
                                     Id = o.Id,
                                     DepartmentName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
                                 };

            var totalCount = await filteredSubDepartments.CountAsync();

            var dbList = await subDepartments.ToListAsync();
            var results = new List<GetSubDepartmentForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetSubDepartmentForViewDto()
                {
                    SubDepartment = new SubDepartmentDto
                    {

                        SubName = o.SubName,
                        Id = o.Id,
                    },
                    DepartmentName = o.DepartmentName
                };

                results.Add(res);
            }

            return new PagedResultDto<GetSubDepartmentForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetSubDepartmentForViewDto> GetSubDepartmentForView(int id)
        {
            var subDepartment = await _subDepartmentRepository.GetAsync(id);

            var output = new GetSubDepartmentForViewDto { SubDepartment = ObjectMapper.Map<SubDepartmentDto>(subDepartment) };

            if (output.SubDepartment.Name != null)
            {
                var _lookupDepartment = await _lookup_departmentRepository.FirstOrDefaultAsync((int)output.SubDepartment.Name);
                output.DepartmentName = _lookupDepartment?.Name?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_SubDepartments_Edit)]
        public async Task<GetSubDepartmentForEditOutput> GetSubDepartmentForEdit(EntityDto input)
        {
            var subDepartment = await _subDepartmentRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetSubDepartmentForEditOutput { SubDepartment = ObjectMapper.Map<CreateOrEditSubDepartmentDto>(subDepartment) };

            if (output.SubDepartment.Name != null)
            {
                var _lookupDepartment = await _lookup_departmentRepository.FirstOrDefaultAsync((int)output.SubDepartment.Name);
                output.DepartmentName = _lookupDepartment?.Name?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditSubDepartmentDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_SubDepartments_Create)]
        protected virtual async Task Create(CreateOrEditSubDepartmentDto input)
        {
            var subDepartment = ObjectMapper.Map<SubDepartment>(input);

            if (AbpSession.TenantId != null)
            {
                subDepartment.TenantId = (int?)AbpSession.TenantId;
            }

            await _subDepartmentRepository.InsertAsync(subDepartment);

        }

        [AbpAuthorize(AppPermissions.Pages_SubDepartments_Edit)]
        protected virtual async Task Update(CreateOrEditSubDepartmentDto input)
        {
            var subDepartment = await _subDepartmentRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, subDepartment);

        }

        [AbpAuthorize(AppPermissions.Pages_SubDepartments_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _subDepartmentRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetSubDepartmentsToExcel(GetAllSubDepartmentsForExcelInput input)
        {

            var filteredSubDepartments = _subDepartmentRepository.GetAll()
                        .Include(e => e.NameFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.SubName.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubNameFilter), e => e.SubName == input.SubNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DepartmentNameFilter), e => e.NameFk != null && e.NameFk.Name == input.DepartmentNameFilter);

            var query = (from o in filteredSubDepartments
                         join o1 in _lookup_departmentRepository.GetAll() on o.Name equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         select new GetSubDepartmentForViewDto()
                         {
                             SubDepartment = new SubDepartmentDto
                             {
                                 SubName = o.SubName,
                                 Id = o.Id
                             },
                             DepartmentName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
                         });

            var subDepartmentListDtos = await query.ToListAsync();

            return _subDepartmentsExcelExporter.ExportToFile(subDepartmentListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_SubDepartments)]
        public async Task<List<SubDepartmentDepartmentLookupTableDto>> GetAllDepartmentForTableDropdown()
        {
            return await _lookup_departmentRepository.GetAll()
                .Select(department => new SubDepartmentDepartmentLookupTableDto
                {
                    Id = department.Id,
                    DisplayName = department == null || department.Name == null ? "" : department.Name.ToString()
                }).ToListAsync();
        }

    }
}