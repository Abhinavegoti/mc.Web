using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace mc.EmployeeInformationMasters.Dtos
{
    public class GetEmployeeInformationMasterForEditOutput
    {
        public CreateOrEditEmployeeInformationMasterDto EmployeeInformationMaster { get; set; }

    }
}