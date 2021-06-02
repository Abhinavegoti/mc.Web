using Abp.Application.Services.Dto;
using System;

namespace mc.Departments.Dtos
{
    public class GetAllDepartmentsForExcelInput
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

    }
}