using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using mc.DataExporting.Excel.NPOI;
using mc.Departments.Dtos;
using mc.Dto;
using mc.Storage;

namespace mc.Departments.Exporting
{
    public class DepartmentsExcelExporter : NpoiExcelExporterBase, IDepartmentsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public DepartmentsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetDepartmentForViewDto> departments)
        {
            return CreateExcelPackage(
                "Departments.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Departments"));

                    AddHeader(
                        sheet,
                        L("Name")
                        );

                    AddObjects(
                        sheet, 2, departments,
                        _ => _.Department.Name
                        );

                });
        }
    }
}