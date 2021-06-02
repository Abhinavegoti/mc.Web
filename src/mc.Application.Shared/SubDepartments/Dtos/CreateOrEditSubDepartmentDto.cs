using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace mc.SubDepartments.Dtos
{
    public class CreateOrEditSubDepartmentDto : EntityDto<int?>
    {

        public string SubName { get; set; }

        public int? Name { get; set; }

    }
}