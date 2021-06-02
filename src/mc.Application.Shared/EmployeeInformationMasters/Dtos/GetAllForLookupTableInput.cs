using Abp.Application.Services.Dto;

namespace mc.EmployeeInformationMasters.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}