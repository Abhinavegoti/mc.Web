using System.Collections.Generic;
using mc.Departments.Dtos;
using mc.Dto;

namespace mc.Departments.Exporting
{
    public interface IDepartmentsExcelExporter
    {
        FileDto ExportToFile(List<GetDepartmentForViewDto> departments);
    }
}