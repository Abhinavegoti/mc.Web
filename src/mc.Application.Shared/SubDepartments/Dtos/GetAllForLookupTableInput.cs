using Abp.Application.Services.Dto;

namespace mc.SubDepartments.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}