using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace mc.EmployeeInformationMasters
{
    [Table("EmployeeInformationMasters")]
    public class EmployeeInformationMaster : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(EmployeeInformationMasterConsts.MaxEmpIdLength, MinimumLength = EmployeeInformationMasterConsts.MinEmpIdLength)]
        public virtual string EmpId { get; set; }

        public virtual long? BioId { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxInternalIdLength, MinimumLength = EmployeeInformationMasterConsts.MinInternalIdLength)]
        public virtual string InternalId { get; set; }

        public virtual DateTime? Doc { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxNameLength, MinimumLength = EmployeeInformationMasterConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxForHLength, MinimumLength = EmployeeInformationMasterConsts.MinForHLength)]
        public virtual string ForH { get; set; }

        public virtual DateTime? Dob { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxPresentAddressLength, MinimumLength = EmployeeInformationMasterConsts.MinPresentAddressLength)]
        public virtual string PresentAddress { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxPermanentAddressLength, MinimumLength = EmployeeInformationMasterConsts.MinPermanentAddressLength)]
        public virtual string PermanentAddress { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxGenderLength, MinimumLength = EmployeeInformationMasterConsts.MinGenderLength)]
        public virtual string Gender { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxContactNoLength, MinimumLength = EmployeeInformationMasterConsts.MinContactNoLength)]
        public virtual string ContactNo { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxAltContactNoLength, MinimumLength = EmployeeInformationMasterConsts.MinAltContactNoLength)]
        public virtual string AltContactNo { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxMaritalStatusLength, MinimumLength = EmployeeInformationMasterConsts.MinMaritalStatusLength)]
        public virtual string MaritalStatus { get; set; }

        public virtual int? NoOfDependents { get; set; }

        public virtual DateTime? ConfirmationDate { get; set; }

        public virtual DateTime? DOJ { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxIhExpLength, MinimumLength = EmployeeInformationMasterConsts.MinIhExpLength)]
        public virtual string IhExp { get; set; }

        public virtual decimal? TotalExp { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxPfNoLength, MinimumLength = EmployeeInformationMasterConsts.MinPfNoLength)]
        public virtual string PfNo { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxEsiNoLength, MinimumLength = EmployeeInformationMasterConsts.MinEsiNoLength)]
        public virtual string EsiNo { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxAcNoLength, MinimumLength = EmployeeInformationMasterConsts.MinAcNoLength)]
        public virtual string AcNo { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxPpNoLength, MinimumLength = EmployeeInformationMasterConsts.MinPpNoLength)]
        public virtual string PpNo { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxPANLength, MinimumLength = EmployeeInformationMasterConsts.MinPANLength)]
        public virtual string PAN { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxBGLength, MinimumLength = EmployeeInformationMasterConsts.MinBGLength)]
        public virtual string BG { get; set; }

        public virtual int? CL { get; set; }

        public virtual int? EL { get; set; }

        public virtual int? SL { get; set; }

        public virtual decimal? BasicSalary { get; set; }

        public virtual decimal? DA { get; set; }

        public virtual decimal? HRA { get; set; }

        public virtual decimal? Conveyance { get; set; }

        public virtual decimal? Incentive { get; set; }

        public virtual decimal? MedicalAllowance { get; set; }

        public virtual decimal? OtherAllowances { get; set; }

        public virtual decimal? TotalSalary { get; set; }

        public virtual string Photo { get; set; }

        public virtual int? UanNo { get; set; }

        public virtual bool IsActive { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxEmployeementUnderLength, MinimumLength = EmployeeInformationMasterConsts.MinEmployeementUnderLength)]
        public virtual string EmployeementUnder { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxDivisionLength, MinimumLength = EmployeeInformationMasterConsts.MinDivisionLength)]
        public virtual string Division { get; set; }

        public virtual long? ContractorId { get; set; }

        public virtual bool MessBill { get; set; }

        public virtual bool Onroll { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxNameInTeluguLength, MinimumLength = EmployeeInformationMasterConsts.MinNameInTeluguLength)]
        public virtual string NameInTelugu { get; set; }

        public virtual DateTime? RjDate { get; set; }

        public virtual string Document { get; set; }

        [StringLength(EmployeeInformationMasterConsts.MaxExtensionLength, MinimumLength = EmployeeInformationMasterConsts.MinExtensionLength)]
        public virtual string Extension { get; set; }

    }
}