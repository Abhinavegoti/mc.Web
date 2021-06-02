using Abp.Application.Services.Dto;
using System;

namespace mc.SubDepartments.Dtos
{
    public class GetAllSubDepartmentsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string SubNameFilter { get; set; }

        public string DepartmentNameFilter { get; set; }

    }
}