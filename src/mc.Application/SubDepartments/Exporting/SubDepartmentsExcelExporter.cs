using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using mc.DataExporting.Excel.NPOI;
using mc.SubDepartments.Dtos;
using mc.Dto;
using mc.Storage;

namespace mc.SubDepartments.Exporting
{
    public class SubDepartmentsExcelExporter : NpoiExcelExporterBase, ISubDepartmentsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public SubDepartmentsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetSubDepartmentForViewDto> subDepartments)
        {
            return CreateExcelPackage(
                "SubDepartments.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("SubDepartments"));

                    AddHeader(
                        sheet,
                        L("SubName"),
                        (L("Department")) + L("Name")
                        );

                    AddObjects(
                        sheet, 2, subDepartments,
                        _ => _.SubDepartment.SubName,
                        _ => _.DepartmentName
                        );

                });
        }
    }
}