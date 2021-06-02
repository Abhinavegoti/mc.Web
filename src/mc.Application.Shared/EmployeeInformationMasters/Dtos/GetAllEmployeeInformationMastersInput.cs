using Abp.Application.Services.Dto;
using System;

namespace mc.EmployeeInformationMasters.Dtos
{
    public class GetAllEmployeeInformationMastersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string EmpIdFilter { get; set; }

        public long? MaxBioIdFilter { get; set; }
        public long? MinBioIdFilter { get; set; }

        public string InternalIdFilter { get; set; }

        public DateTime? MaxDocFilter { get; set; }
        public DateTime? MinDocFilter { get; set; }

        public string NameFilter { get; set; }

        public string ForHFilter { get; set; }

        public DateTime? MaxDobFilter { get; set; }
        public DateTime? MinDobFilter { get; set; }

        public string PresentAddressFilter { get; set; }

        public string PermanentAddressFilter { get; set; }

        public string GenderFilter { get; set; }

        public string ContactNoFilter { get; set; }

        public string AltContactNoFilter { get; set; }

        public string MaritalStatusFilter { get; set; }

        public int? MaxNoOfDependentsFilter { get; set; }
        public int? MinNoOfDependentsFilter { get; set; }

        public DateTime? MaxConfirmationDateFilter { get; set; }
        public DateTime? MinConfirmationDateFilter { get; set; }

        public DateTime? MaxDOJFilter { get; set; }
        public DateTime? MinDOJFilter { get; set; }

        public string IhExpFilter { get; set; }

        public decimal? MaxTotalExpFilter { get; set; }
        public decimal? MinTotalExpFilter { get; set; }

        public string PfNoFilter { get; set; }

        public string EsiNoFilter { get; set; }

        public string AcNoFilter { get; set; }

        public string PpNoFilter { get; set; }

        public string PANFilter { get; set; }

        public string BGFilter { get; set; }

        public int? MaxCLFilter { get; set; }
        public int? MinCLFilter { get; set; }

        public int? MaxELFilter { get; set; }
        public int? MinELFilter { get; set; }

        public int? MaxSLFilter { get; set; }
        public int? MinSLFilter { get; set; }

        public decimal? MaxBasicSalaryFilter { get; set; }
        public decimal? MinBasicSalaryFilter { get; set; }

        public decimal? MaxDAFilter { get; set; }
        public decimal? MinDAFilter { get; set; }

        public decimal? MaxHRAFilter { get; set; }
        public decimal? MinHRAFilter { get; set; }

        public decimal? MaxConveyanceFilter { get; set; }
        public decimal? MinConveyanceFilter { get; set; }

        public decimal? MaxIncentiveFilter { get; set; }
        public decimal? MinIncentiveFilter { get; set; }

        public decimal? MaxMedicalAllowanceFilter { get; set; }
        public decimal? MinMedicalAllowanceFilter { get; set; }

        public decimal? MaxOtherAllowancesFilter { get; set; }
        public decimal? MinOtherAllowancesFilter { get; set; }

        public decimal? MaxTotalSalaryFilter { get; set; }
        public decimal? MinTotalSalaryFilter { get; set; }

        public string PhotoFilter { get; set; }

        public int? MaxUanNoFilter { get; set; }
        public int? MinUanNoFilter { get; set; }

        public int? IsActiveFilter { get; set; }

        public string EmployeementUnderFilter { get; set; }

        public string DivisionFilter { get; set; }

        public long? MaxContractorIdFilter { get; set; }
        public long? MinContractorIdFilter { get; set; }

        public int? MessBillFilter { get; set; }

        public int? OnrollFilter { get; set; }

        public string NameInTeluguFilter { get; set; }

        public DateTime? MaxRjDateFilter { get; set; }
        public DateTime? MinRjDateFilter { get; set; }

        public string DocumentFilter { get; set; }

        public string ExtensionFilter { get; set; }

    }
}