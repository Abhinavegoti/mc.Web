using System.Collections.Generic;
using mc.EmployeeInformationMasters.Dtos;
using mc.Dto;

namespace mc.EmployeeInformationMasters.Exporting
{
    public interface IEmployeeInformationMastersExcelExporter
    {
        FileDto ExportToFile(List<GetEmployeeInformationMasterForViewDto> employeeInformationMasters);
    }
}