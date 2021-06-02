using System;
using Abp.Application.Services.Dto;

namespace mc.EmployeeInformationMasters.Dtos
{
    public class EmployeeInformationMasterDto : EntityDto
    {
        public string EmpId { get; set; }

        public long? BioId { get; set; }

        public string InternalId { get; set; }

        public DateTime? Doc { get; set; }

        public string Name { get; set; }

        public string ForH { get; set; }

        public DateTime? Dob { get; set; }

        public string PresentAddress { get; set; }

        public string PermanentAddress { get; set; }

        public string Gender { get; set; }

        public string ContactNo { get; set; }

        public string AltContactNo { get; set; }

        public string MaritalStatus { get; set; }

        public int? NoOfDependents { get; set; }

        public DateTime? ConfirmationDate { get; set; }

        public DateTime? DOJ { get; set; }

        public string IhExp { get; set; }

        public decimal? TotalExp { get; set; }

        public string PfNo { get; set; }

        public string EsiNo { get; set; }

        public string AcNo { get; set; }

        public string PpNo { get; set; }

        public string PAN { get; set; }

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

        public string EmployeementUnder { get; set; }

        public string Division { get; set; }

        public long? ContractorId { get; set; }

        public bool MessBill { get; set; }

        public bool Onroll { get; set; }

        public string NameInTelugu { get; set; }

        public DateTime? RjDate { get; set; }

        public string Document { get; set; }

        public string Extension { get; set; }

    }
}