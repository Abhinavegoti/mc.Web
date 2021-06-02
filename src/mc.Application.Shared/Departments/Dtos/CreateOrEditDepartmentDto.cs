using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace mc.Departments.Dtos
{
    public class CreateOrEditDepartmentDto : EntityDto<int?>
    {

        [Required]
        public string Name { get; set; }

    }
}