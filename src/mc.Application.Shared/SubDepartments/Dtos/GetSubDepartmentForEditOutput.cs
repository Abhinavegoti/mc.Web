using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace mc.SubDepartments.Dtos
{
    public class GetSubDepartmentForEditOutput
    {
        public CreateOrEditSubDepartmentDto SubDepartment { get; set; }

        public string DepartmentName { get; set; }

    }
}