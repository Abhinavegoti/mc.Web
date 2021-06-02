using System;
using Abp.Application.Services.Dto;

namespace mc.SubDepartments.Dtos
{
    public class SubDepartmentDto : EntityDto
    {
        public string SubName { get; set; }

        public int? Name { get; set; }

    }
}