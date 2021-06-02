using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using mc.EmployeeInformationMasters.Exporting;
using mc.EmployeeInformationMasters.Dtos;
using mc.Dto;
using Abp.Application.Services.Dto;
using mc.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using mc.Storage;

namespace mc.EmployeeInformationMasters
{
    [AbpAuthorize(AppPermissions.Pages_EmployeeInformationMasters)]
    public class EmployeeInformationMastersAppService : mcAppServiceBase, IEmployeeInformationMastersAppService
    {
        private readonly IRepository<EmployeeInformationMaster> _employeeInformationMasterRepository;
        private readonly IEmployeeInformationMastersExcelExporter _employeeInformationMastersExcelExporter;

        public EmployeeInformationMastersAppService(IRepository<EmployeeInformationMaster> employeeInformationMasterRepository, IEmployeeInformationMastersExcelExporter employeeInformationMastersExcelExporter)
        {
            _employeeInformationMasterRepository = employeeInformationMasterRepository;
            _employeeInformationMastersExcelExporter = employeeInformationMastersExcelExporter;

        }

        public async Task<PagedResultDto<GetEmployeeInformationMasterForViewDto>> GetAll(GetAllEmployeeInformationMastersInput input)
        {

            var filteredEmployeeInformationMasters = _employeeInformationMasterRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.EmpId.Contains(input.Filter) || e.InternalId.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.ForH.Contains(input.Filter) || e.PresentAddress.Contains(input.Filter) || e.PermanentAddress.Contains(input.Filter) || e.Gender.Contains(input.Filter) || e.ContactNo.Contains(input.Filter) || e.AltContactNo.Contains(input.Filter) || e.MaritalStatus.Contains(input.Filter) || e.IhExp.Contains(input.Filter) || e.PfNo.Contains(input.Filter) || e.EsiNo.Contains(input.Filter) || e.AcNo.Contains(input.Filter) || e.PpNo.Contains(input.Filter) || e.PAN.Contains(input.Filter) || e.BG.Contains(input.Filter) || e.Photo.Contains(input.Filter) || e.EmployeementUnder.Contains(input.Filter) || e.Division.Contains(input.Filter) || e.NameInTelugu.Contains(input.Filter) || e.Document.Contains(input.Filter) || e.Extension.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmpIdFilter), e => e.EmpId == input.EmpIdFilter)
                        .WhereIf(input.MinBioIdFilter != null, e => e.BioId >= input.MinBioIdFilter)
                        .WhereIf(input.MaxBioIdFilter != null, e => e.BioId <= input.MaxBioIdFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.InternalIdFilter), e => e.InternalId == input.InternalIdFilter)
                        .WhereIf(input.MinDocFilter != null, e => e.Doc >= input.MinDocFilter)
                        .WhereIf(input.MaxDocFilter != null, e => e.Doc <= input.MaxDocFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ForHFilter), e => e.ForH == input.ForHFilter)
                        .WhereIf(input.MinDobFilter != null, e => e.Dob >= input.MinDobFilter)
                        .WhereIf(input.MaxDobFilter != null, e => e.Dob <= input.MaxDobFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PresentAddressFilter), e => e.PresentAddress == input.PresentAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PermanentAddressFilter), e => e.PermanentAddress == input.PermanentAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.GenderFilter), e => e.Gender == input.GenderFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactNoFilter), e => e.ContactNo == input.ContactNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AltContactNoFilter), e => e.AltContactNo == input.AltContactNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MaritalStatusFilter), e => e.MaritalStatus == input.MaritalStatusFilter)
                        .WhereIf(input.MinNoOfDependentsFilter != null, e => e.NoOfDependents >= input.MinNoOfDependentsFilter)
                        .WhereIf(input.MaxNoOfDependentsFilter != null, e => e.NoOfDependents <= input.MaxNoOfDependentsFilter)
                        .WhereIf(input.MinConfirmationDateFilter != null, e => e.ConfirmationDate >= input.MinConfirmationDateFilter)
                        .WhereIf(input.MaxConfirmationDateFilter != null, e => e.ConfirmationDate <= input.MaxConfirmationDateFilter)
                        .WhereIf(input.MinDOJFilter != null, e => e.DOJ >= input.MinDOJFilter)
                        .WhereIf(input.MaxDOJFilter != null, e => e.DOJ <= input.MaxDOJFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.IhExpFilter), e => e.IhExp == input.IhExpFilter)
                        .WhereIf(input.MinTotalExpFilter != null, e => e.TotalExp >= input.MinTotalExpFilter)
                        .WhereIf(input.MaxTotalExpFilter != null, e => e.TotalExp <= input.MaxTotalExpFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PfNoFilter), e => e.PfNo == input.PfNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EsiNoFilter), e => e.EsiNo == input.EsiNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AcNoFilter), e => e.AcNo == input.AcNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PpNoFilter), e => e.PpNo == input.PpNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PANFilter), e => e.PAN == input.PANFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BGFilter), e => e.BG == input.BGFilter)
                        .WhereIf(input.MinCLFilter != null, e => e.CL >= input.MinCLFilter)
                        .WhereIf(input.MaxCLFilter != null, e => e.CL <= input.MaxCLFilter)
                        .WhereIf(input.MinELFilter != null, e => e.EL >= input.MinELFilter)
                        .WhereIf(input.MaxELFilter != null, e => e.EL <= input.MaxELFilter)
                        .WhereIf(input.MinSLFilter != null, e => e.SL >= input.MinSLFilter)
                        .WhereIf(input.MaxSLFilter != null, e => e.SL <= input.MaxSLFilter)
                        .WhereIf(input.MinBasicSalaryFilter != null, e => e.BasicSalary >= input.MinBasicSalaryFilter)
                        .WhereIf(input.MaxBasicSalaryFilter != null, e => e.BasicSalary <= input.MaxBasicSalaryFilter)
                        .WhereIf(input.MinDAFilter != null, e => e.DA >= input.MinDAFilter)
                        .WhereIf(input.MaxDAFilter != null, e => e.DA <= input.MaxDAFilter)
                        .WhereIf(input.MinHRAFilter != null, e => e.HRA >= input.MinHRAFilter)
                        .WhereIf(input.MaxHRAFilter != null, e => e.HRA <= input.MaxHRAFilter)
                        .WhereIf(input.MinConveyanceFilter != null, e => e.Conveyance >= input.MinConveyanceFilter)
                        .WhereIf(input.MaxConveyanceFilter != null, e => e.Conveyance <= input.MaxConveyanceFilter)
                        .WhereIf(input.MinIncentiveFilter != null, e => e.Incentive >= input.MinIncentiveFilter)
                        .WhereIf(input.MaxIncentiveFilter != null, e => e.Incentive <= input.MaxIncentiveFilter)
                        .WhereIf(input.MinMedicalAllowanceFilter != null, e => e.MedicalAllowance >= input.MinMedicalAllowanceFilter)
                        .WhereIf(input.MaxMedicalAllowanceFilter != null, e => e.MedicalAllowance <= input.MaxMedicalAllowanceFilter)
                        .WhereIf(input.MinOtherAllowancesFilter != null, e => e.OtherAllowances >= input.MinOtherAllowancesFilter)
                        .WhereIf(input.MaxOtherAllowancesFilter != null, e => e.OtherAllowances <= input.MaxOtherAllowancesFilter)
                        .WhereIf(input.MinTotalSalaryFilter != null, e => e.TotalSalary >= input.MinTotalSalaryFilter)
                        .WhereIf(input.MaxTotalSalaryFilter != null, e => e.TotalSalary <= input.MaxTotalSalaryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PhotoFilter), e => e.Photo == input.PhotoFilter)
                        .WhereIf(input.MinUanNoFilter != null, e => e.UanNo >= input.MinUanNoFilter)
                        .WhereIf(input.MaxUanNoFilter != null, e => e.UanNo <= input.MaxUanNoFilter)
                        .WhereIf(input.IsActiveFilter.HasValue && input.IsActiveFilter > -1, e => (input.IsActiveFilter == 1 && e.IsActive) || (input.IsActiveFilter == 0 && !e.IsActive))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmployeementUnderFilter), e => e.EmployeementUnder == input.EmployeementUnderFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DivisionFilter), e => e.Division == input.DivisionFilter)
                        .WhereIf(input.MinContractorIdFilter != null, e => e.ContractorId >= input.MinContractorIdFilter)
                        .WhereIf(input.MaxContractorIdFilter != null, e => e.ContractorId <= input.MaxContractorIdFilter)
                        .WhereIf(input.MessBillFilter.HasValue && input.MessBillFilter > -1, e => (input.MessBillFilter == 1 && e.MessBill) || (input.MessBillFilter == 0 && !e.MessBill))
                        .WhereIf(input.OnrollFilter.HasValue && input.OnrollFilter > -1, e => (input.OnrollFilter == 1 && e.Onroll) || (input.OnrollFilter == 0 && !e.Onroll))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameInTeluguFilter), e => e.NameInTelugu == input.NameInTeluguFilter)
                        .WhereIf(input.MinRjDateFilter != null, e => e.RjDate >= input.MinRjDateFilter)
                        .WhereIf(input.MaxRjDateFilter != null, e => e.RjDate <= input.MaxRjDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DocumentFilter), e => e.Document == input.DocumentFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ExtensionFilter), e => e.Extension == input.ExtensionFilter);

            var pagedAndFilteredEmployeeInformationMasters = filteredEmployeeInformationMasters
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var employeeInformationMasters = from o in pagedAndFilteredEmployeeInformationMasters
                                             select new
                                             {

                                                 o.EmpId,
                                                 o.BioId,
                                                 o.InternalId,
                                                 o.Doc,
                                                 o.Name,
                                                 o.ForH,
                                                 o.Dob,
                                                 o.PresentAddress,
                                                 o.PermanentAddress,
                                                 o.Gender,
                                                 o.ContactNo,
                                                 o.AltContactNo,
                                                 o.MaritalStatus,
                                                 o.NoOfDependents,
                                                 o.ConfirmationDate,
                                                 o.DOJ,
                                                 o.IhExp,
                                                 o.TotalExp,
                                                 o.PfNo,
                                                 o.EsiNo,
                                                 o.AcNo,
                                                 o.PpNo,
                                                 o.PAN,
                                                 o.BG,
                                                 o.CL,
                                                 o.EL,
                                                 o.SL,
                                                 o.BasicSalary,
                                                 o.DA,
                                                 o.HRA,
                                                 o.Conveyance,
                                                 o.Incentive,
                                                 o.MedicalAllowance,
                                                 o.OtherAllowances,
                                                 o.TotalSalary,
                                                 o.Photo,
                                                 o.UanNo,
                                                 o.IsActive,
                                                 o.EmployeementUnder,
                                                 o.Division,
                                                 o.ContractorId,
                                                 o.MessBill,
                                                 o.Onroll,
                                                 o.NameInTelugu,
                                                 o.RjDate,
                                                 o.Document,
                                                 o.Extension,
                                                 Id = o.Id
                                             };

            var totalCount = await filteredEmployeeInformationMasters.CountAsync();

            var dbList = await employeeInformationMasters.ToListAsync();
            var results = new List<GetEmployeeInformationMasterForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetEmployeeInformationMasterForViewDto()
                {
                    EmployeeInformationMaster = new EmployeeInformationMasterDto
                    {

                        EmpId = o.EmpId,
                        BioId = o.BioId,
                        InternalId = o.InternalId,
                        Doc = o.Doc,
                        Name = o.Name,
                        ForH = o.ForH,
                        Dob = o.Dob,
                        PresentAddress = o.PresentAddress,
                        PermanentAddress = o.PermanentAddress,
                        Gender = o.Gender,
                        ContactNo = o.ContactNo,
                        AltContactNo = o.AltContactNo,
                        MaritalStatus = o.MaritalStatus,
                        NoOfDependents = o.NoOfDependents,
                        ConfirmationDate = o.ConfirmationDate,
                        DOJ = o.DOJ,
                        IhExp = o.IhExp,
                        TotalExp = o.TotalExp,
                        PfNo = o.PfNo,
                        EsiNo = o.EsiNo,
                        AcNo = o.AcNo,
                        PpNo = o.PpNo,
                        PAN = o.PAN,
                        BG = o.BG,
                        CL = o.CL,
                        EL = o.EL,
                        SL = o.SL,
                        BasicSalary = o.BasicSalary,
                        DA = o.DA,
                        HRA = o.HRA,
                        Conveyance = o.Conveyance,
                        Incentive = o.Incentive,
                        MedicalAllowance = o.MedicalAllowance,
                        OtherAllowances = o.OtherAllowances,
                        TotalSalary = o.TotalSalary,
                        Photo = o.Photo,
                        UanNo = o.UanNo,
                        IsActive = o.IsActive,
                        EmployeementUnder = o.EmployeementUnder,
                        Division = o.Division,
                        ContractorId = o.ContractorId,
                        MessBill = o.MessBill,
                        Onroll = o.Onroll,
                        NameInTelugu = o.NameInTelugu,
                        RjDate = o.RjDate,
                        Document = o.Document,
                        Extension = o.Extension,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetEmployeeInformationMasterForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetEmployeeInformationMasterForViewDto> GetEmployeeInformationMasterForView(int id)
        {
            var employeeInformationMaster = await _employeeInformationMasterRepository.GetAsync(id);

            var output = new GetEmployeeInformationMasterForViewDto { EmployeeInformationMaster = ObjectMapper.Map<EmployeeInformationMasterDto>(employeeInformationMaster) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_EmployeeInformationMasters_Edit)]
        public async Task<GetEmployeeInformationMasterForEditOutput> GetEmployeeInformationMasterForEdit(EntityDto input)
        {
            var employeeInformationMaster = await _employeeInformationMasterRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetEmployeeInformationMasterForEditOutput { EmployeeInformationMaster = ObjectMapper.Map<CreateOrEditEmployeeInformationMasterDto>(employeeInformationMaster) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditEmployeeInformationMasterDto input)
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

        [AbpAuthorize(AppPermissions.Pages_EmployeeInformationMasters_Create)]
        protected virtual async Task Create(CreateOrEditEmployeeInformationMasterDto input)
        {
            var employeeInformationMaster = ObjectMapper.Map<EmployeeInformationMaster>(input);

            if (AbpSession.TenantId != null)
            {
                employeeInformationMaster.TenantId = (int?)AbpSession.TenantId;
            }

            await _employeeInformationMasterRepository.InsertAsync(employeeInformationMaster);

        }

        [AbpAuthorize(AppPermissions.Pages_EmployeeInformationMasters_Edit)]
        protected virtual async Task Update(CreateOrEditEmployeeInformationMasterDto input)
        {
            var employeeInformationMaster = await _employeeInformationMasterRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, employeeInformationMaster);

        }

        [AbpAuthorize(AppPermissions.Pages_EmployeeInformationMasters_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _employeeInformationMasterRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetEmployeeInformationMastersToExcel(GetAllEmployeeInformationMastersForExcelInput input)
        {

            var filteredEmployeeInformationMasters = _employeeInformationMasterRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.EmpId.Contains(input.Filter) || e.InternalId.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.ForH.Contains(input.Filter) || e.PresentAddress.Contains(input.Filter) || e.PermanentAddress.Contains(input.Filter) || e.Gender.Contains(input.Filter) || e.ContactNo.Contains(input.Filter) || e.AltContactNo.Contains(input.Filter) || e.MaritalStatus.Contains(input.Filter) || e.IhExp.Contains(input.Filter) || e.PfNo.Contains(input.Filter) || e.EsiNo.Contains(input.Filter) || e.AcNo.Contains(input.Filter) || e.PpNo.Contains(input.Filter) || e.PAN.Contains(input.Filter) || e.BG.Contains(input.Filter) || e.Photo.Contains(input.Filter) || e.EmployeementUnder.Contains(input.Filter) || e.Division.Contains(input.Filter) || e.NameInTelugu.Contains(input.Filter) || e.Document.Contains(input.Filter) || e.Extension.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmpIdFilter), e => e.EmpId == input.EmpIdFilter)
                        .WhereIf(input.MinBioIdFilter != null, e => e.BioId >= input.MinBioIdFilter)
                        .WhereIf(input.MaxBioIdFilter != null, e => e.BioId <= input.MaxBioIdFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.InternalIdFilter), e => e.InternalId == input.InternalIdFilter)
                        .WhereIf(input.MinDocFilter != null, e => e.Doc >= input.MinDocFilter)
                        .WhereIf(input.MaxDocFilter != null, e => e.Doc <= input.MaxDocFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ForHFilter), e => e.ForH == input.ForHFilter)
                        .WhereIf(input.MinDobFilter != null, e => e.Dob >= input.MinDobFilter)
                        .WhereIf(input.MaxDobFilter != null, e => e.Dob <= input.MaxDobFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PresentAddressFilter), e => e.PresentAddress == input.PresentAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PermanentAddressFilter), e => e.PermanentAddress == input.PermanentAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.GenderFilter), e => e.Gender == input.GenderFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactNoFilter), e => e.ContactNo == input.ContactNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AltContactNoFilter), e => e.AltContactNo == input.AltContactNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MaritalStatusFilter), e => e.MaritalStatus == input.MaritalStatusFilter)
                        .WhereIf(input.MinNoOfDependentsFilter != null, e => e.NoOfDependents >= input.MinNoOfDependentsFilter)
                        .WhereIf(input.MaxNoOfDependentsFilter != null, e => e.NoOfDependents <= input.MaxNoOfDependentsFilter)
                        .WhereIf(input.MinConfirmationDateFilter != null, e => e.ConfirmationDate >= input.MinConfirmationDateFilter)
                        .WhereIf(input.MaxConfirmationDateFilter != null, e => e.ConfirmationDate <= input.MaxConfirmationDateFilter)
                        .WhereIf(input.MinDOJFilter != null, e => e.DOJ >= input.MinDOJFilter)
                        .WhereIf(input.MaxDOJFilter != null, e => e.DOJ <= input.MaxDOJFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.IhExpFilter), e => e.IhExp == input.IhExpFilter)
                        .WhereIf(input.MinTotalExpFilter != null, e => e.TotalExp >= input.MinTotalExpFilter)
                        .WhereIf(input.MaxTotalExpFilter != null, e => e.TotalExp <= input.MaxTotalExpFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PfNoFilter), e => e.PfNo == input.PfNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EsiNoFilter), e => e.EsiNo == input.EsiNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AcNoFilter), e => e.AcNo == input.AcNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PpNoFilter), e => e.PpNo == input.PpNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PANFilter), e => e.PAN == input.PANFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BGFilter), e => e.BG == input.BGFilter)
                        .WhereIf(input.MinCLFilter != null, e => e.CL >= input.MinCLFilter)
                        .WhereIf(input.MaxCLFilter != null, e => e.CL <= input.MaxCLFilter)
                        .WhereIf(input.MinELFilter != null, e => e.EL >= input.MinELFilter)
                        .WhereIf(input.MaxELFilter != null, e => e.EL <= input.MaxELFilter)
                        .WhereIf(input.MinSLFilter != null, e => e.SL >= input.MinSLFilter)
                        .WhereIf(input.MaxSLFilter != null, e => e.SL <= input.MaxSLFilter)
                        .WhereIf(input.MinBasicSalaryFilter != null, e => e.BasicSalary >= input.MinBasicSalaryFilter)
                        .WhereIf(input.MaxBasicSalaryFilter != null, e => e.BasicSalary <= input.MaxBasicSalaryFilter)
                        .WhereIf(input.MinDAFilter != null, e => e.DA >= input.MinDAFilter)
                        .WhereIf(input.MaxDAFilter != null, e => e.DA <= input.MaxDAFilter)
                        .WhereIf(input.MinHRAFilter != null, e => e.HRA >= input.MinHRAFilter)
                        .WhereIf(input.MaxHRAFilter != null, e => e.HRA <= input.MaxHRAFilter)
                        .WhereIf(input.MinConveyanceFilter != null, e => e.Conveyance >= input.MinConveyanceFilter)
                        .WhereIf(input.MaxConveyanceFilter != null, e => e.Conveyance <= input.MaxConveyanceFilter)
                        .WhereIf(input.MinIncentiveFilter != null, e => e.Incentive >= input.MinIncentiveFilter)
                        .WhereIf(input.MaxIncentiveFilter != null, e => e.Incentive <= input.MaxIncentiveFilter)
                        .WhereIf(input.MinMedicalAllowanceFilter != null, e => e.MedicalAllowance >= input.MinMedicalAllowanceFilter)
                        .WhereIf(input.MaxMedicalAllowanceFilter != null, e => e.MedicalAllowance <= input.MaxMedicalAllowanceFilter)
                        .WhereIf(input.MinOtherAllowancesFilter != null, e => e.OtherAllowances >= input.MinOtherAllowancesFilter)
                        .WhereIf(input.MaxOtherAllowancesFilter != null, e => e.OtherAllowances <= input.MaxOtherAllowancesFilter)
                        .WhereIf(input.MinTotalSalaryFilter != null, e => e.TotalSalary >= input.MinTotalSalaryFilter)
                        .WhereIf(input.MaxTotalSalaryFilter != null, e => e.TotalSalary <= input.MaxTotalSalaryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PhotoFilter), e => e.Photo == input.PhotoFilter)
                        .WhereIf(input.MinUanNoFilter != null, e => e.UanNo >= input.MinUanNoFilter)
                        .WhereIf(input.MaxUanNoFilter != null, e => e.UanNo <= input.MaxUanNoFilter)
                        .WhereIf(input.IsActiveFilter.HasValue && input.IsActiveFilter > -1, e => (input.IsActiveFilter == 1 && e.IsActive) || (input.IsActiveFilter == 0 && !e.IsActive))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmployeementUnderFilter), e => e.EmployeementUnder == input.EmployeementUnderFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DivisionFilter), e => e.Division == input.DivisionFilter)
                        .WhereIf(input.MinContractorIdFilter != null, e => e.ContractorId >= input.MinContractorIdFilter)
                        .WhereIf(input.MaxContractorIdFilter != null, e => e.ContractorId <= input.MaxContractorIdFilter)
                        .WhereIf(input.MessBillFilter.HasValue && input.MessBillFilter > -1, e => (input.MessBillFilter == 1 && e.MessBill) || (input.MessBillFilter == 0 && !e.MessBill))
                        .WhereIf(input.OnrollFilter.HasValue && input.OnrollFilter > -1, e => (input.OnrollFilter == 1 && e.Onroll) || (input.OnrollFilter == 0 && !e.Onroll))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameInTeluguFilter), e => e.NameInTelugu == input.NameInTeluguFilter)
                        .WhereIf(input.MinRjDateFilter != null, e => e.RjDate >= input.MinRjDateFilter)
                        .WhereIf(input.MaxRjDateFilter != null, e => e.RjDate <= input.MaxRjDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DocumentFilter), e => e.Document == input.DocumentFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ExtensionFilter), e => e.Extension == input.ExtensionFilter);

            var query = (from o in filteredEmployeeInformationMasters
                         select new GetEmployeeInformationMasterForViewDto()
                         {
                             EmployeeInformationMaster = new EmployeeInformationMasterDto
                             {
                                 EmpId = o.EmpId,
                                 BioId = o.BioId,
                                 InternalId = o.InternalId,
                                 Doc = o.Doc,
                                 Name = o.Name,
                                 ForH = o.ForH,
                                 Dob = o.Dob,
                                 PresentAddress = o.PresentAddress,
                                 PermanentAddress = o.PermanentAddress,
                                 Gender = o.Gender,
                                 ContactNo = o.ContactNo,
                                 AltContactNo = o.AltContactNo,
                                 MaritalStatus = o.MaritalStatus,
                                 NoOfDependents = o.NoOfDependents,
                                 ConfirmationDate = o.ConfirmationDate,
                                 DOJ = o.DOJ,
                                 IhExp = o.IhExp,
                                 TotalExp = o.TotalExp,
                                 PfNo = o.PfNo,
                                 EsiNo = o.EsiNo,
                                 AcNo = o.AcNo,
                                 PpNo = o.PpNo,
                                 PAN = o.PAN,
                                 BG = o.BG,
                                 CL = o.CL,
                                 EL = o.EL,
                                 SL = o.SL,
                                 BasicSalary = o.BasicSalary,
                                 DA = o.DA,
                                 HRA = o.HRA,
                                 Conveyance = o.Conveyance,
                                 Incentive = o.Incentive,
                                 MedicalAllowance = o.MedicalAllowance,
                                 OtherAllowances = o.OtherAllowances,
                                 TotalSalary = o.TotalSalary,
                                 Photo = o.Photo,
                                 UanNo = o.UanNo,
                                 IsActive = o.IsActive,
                                 EmployeementUnder = o.EmployeementUnder,
                                 Division = o.Division,
                                 ContractorId = o.ContractorId,
                                 MessBill = o.MessBill,
                                 Onroll = o.Onroll,
                                 NameInTelugu = o.NameInTelugu,
                                 RjDate = o.RjDate,
                                 Document = o.Document,
                                 Extension = o.Extension,
                                 Id = o.Id
                             }
                         });

            var employeeInformationMasterListDtos = await query.ToListAsync();

            return _employeeInformationMastersExcelExporter.ExportToFile(employeeInformationMasterListDtos);
        }

    }
}