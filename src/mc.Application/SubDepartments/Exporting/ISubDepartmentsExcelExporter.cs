using System.Collections.Generic;
using mc.SubDepartments.Dtos;
using mc.Dto;

namespace mc.SubDepartments.Exporting
{
    public interface ISubDepartmentsExcelExporter
    {
        FileDto ExportToFile(List<GetSubDepartmentForViewDto> subDepartments);
    }
}