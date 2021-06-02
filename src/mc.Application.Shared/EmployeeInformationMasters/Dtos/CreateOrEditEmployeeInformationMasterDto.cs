using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace mc.EmployeeInformationMasters.Dtos
{
    public class CreateOrEditEmployeeInformationMasterDto : EntityDto<int?>
    {

        [Required]
        [StringLength(EmployeeInformationMasterConsts.MaxEmpIdLength, MinimumLength = EmployeeInformationMasterConsts.MinEmpIdLength)]
        public string EmpId { get; set; }

        public long? BioId { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxInternalIdLength, MinimumLength = EmployeeInformationMasterConsts.MinInternalIdLength)]
        public string InternalId { get; set; }

        public DateTime? Doc { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxNameLength, MinimumLength = EmployeeInformationMasterConsts.MinNameLength)]
        public string Name { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxForHLength, MinimumLength = EmployeeInformationMasterConsts.MinForHLength)]
        public string ForH { get; set; }

        public DateTime? Dob { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxPresentAddressLength, MinimumLength = EmployeeInformationMasterConsts.MinPresentAddressLength)]
        public string PresentAddress { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxPermanentAddressLength, MinimumLength = EmployeeInformationMasterConsts.MinPermanentAddressLength)]
        public string PermanentAddress { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxGenderLength, MinimumLength = EmployeeInformationMasterConsts.MinGenderLength)]
        public string Gender { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxContactNoLength, MinimumLength = EmployeeInformationMasterConsts.MinContactNoLength)]
        public string ContactNo { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxAltContactNoLength, MinimumLength = EmployeeInformationMasterConsts.MinAltContactNoLength)]
        public string AltContactNo { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxMaritalStatusLength, MinimumLength = EmployeeInformationMasterConsts.MinMaritalStatusLength)]
        public string MaritalStatus { get; set; }

        public int? NoOfDependents { get; set; }

        public DateTime? ConfirmationDate { get; set; }

        public DateTime? DOJ { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxIhExpLength, MinimumLength = EmployeeInformationMasterConsts.MinIhExpLength)]
        public string IhExp { get; set; }

        public decimal? TotalExp { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxPfNoLength, MinimumLength = EmployeeInformationMasterConsts.MinPfNoLength)]
        public string PfNo { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxEsiNoLength, MinimumLength = EmployeeInformationMasterConsts.MinEsiNoLength)]
        public string EsiNo { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxAcNoLength, MinimumLength = EmployeeInformationMasterConsts.MinAcNoLength)]
        public string AcNo { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxPpNoLength, MinimumLength = EmployeeInformationMasterConsts.MinPpNoLength)]
        public string PpNo { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxPANLength, MinimumLength = EmployeeInformationMasterConsts.MinPANLength)]
        public string PAN { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxBGLength, MinimumLength = EmployeeInformationMasterConsts.MinBGLength)]
        public string BG { get; set; }

        public int? CL { get; set; }

        public int? EL { get; set; }

        public int? SL { get; set; }

        public decimal? BasicSalary { get; set; }

        public decimal? DA { get; set; }

        public decimal? HRA { get; set; }

        public decimal? Conveyance { get; set; }

        public decimal? Incentive { get; set; }

        public decimal? MedicalAllowance { get; set; }

        public decimal? OtherAllowances { get; set; }

        public decimal? TotalSalary { get; set; }

        public string Photo { get; set; }

        public int? UanNo { get; set; }

        public bool IsActive { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxEmployeementUnderLength, MinimumLength = EmployeeInformationMasterConsts.MinEmployeementUnderLength)]
        public string EmployeementUnder { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxDivisionLength, MinimumLength = EmployeeInformationMasterConsts.MinDivisionLength)]
        public string Division { get; set; }

        public long? ContractorId { get; set; }

        public bool MessBill { get; set; }

        public bool Onroll { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxNameInTeluguLength, MinimumLength = EmployeeInformationMasterConsts.MinNameInTeluguLength)]
        public string NameInTelugu { get; set; }

        public DateTime? RjDate { get; set; }

        public string Document { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxExtensionLength, MinimumLength = EmployeeInformationMasterConsts.MinExtensionLength)]
        public string Extension { get; set; }

    }
}