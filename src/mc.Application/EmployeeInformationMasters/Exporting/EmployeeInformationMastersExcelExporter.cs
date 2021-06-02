using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using mc.DataExporting.Excel.NPOI;
using mc.EmployeeInformationMasters.Dtos;
using mc.Dto;
using mc.Storage;

namespace mc.EmployeeInformationMasters.Exporting
{
    public class EmployeeInformationMastersExcelExporter : NpoiExcelExporterBase, IEmployeeInformationMastersExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public EmployeeInformationMastersExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetEmployeeInformationMasterForViewDto> employeeInformationMasters)
        {
            return CreateExcelPackage(
                "EmployeeInformationMasters.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("EmployeeInformationMasters"));

                    AddHeader(
                        sheet,
                        L("EmpId"),
                        L("BioId"),
                        L("InternalId"),
                        L("Doc"),
                        L("Name"),
                        L("ForH"),
                        L("Dob"),
                        L("PresentAddress"),
                        L("PermanentAddress"),
                        L("Gender"),
                        L("ContactNo"),
                        L("AltContactNo"),
                        L("MaritalStatus"),
                        L("NoOfDependents"),
                        L("ConfirmationDate"),
                        L("DOJ"),
                        L("IhExp"),
                        L("TotalExp"),
                        L("PfNo"),
                        L("EsiNo"),
                        L("AcNo"),
                        L("PpNo"),
                        L("PAN"),
                        L("BG"),
                        L("CL"),
                        L("EL"),
                        L("SL"),
                        L("BasicSalary"),
                        L("DA"),
                        L("HRA"),
                        L("Conveyance"),
                        L("Incentive"),
                        L("MedicalAllowance"),
                        L("OtherAllowances"),
                        L("TotalSalary"),
                        L("Photo"),
                        L("UanNo"),
                        L("IsActive"),
                        L("EmployeementUnder"),
                        L("Division"),
                        L("ContractorId"),
                        L("MessBill"),
                        L("Onroll"),
                        L("NameInTelugu"),
                        L("RjDate"),
                        L("Document"),
                        L("Extension")
                        );

                    AddObjects(
                        sheet, 2, employeeInformationMasters,
                        _ => _.EmployeeInformationMaster.EmpId,
                        _ => _.EmployeeInformationMaster.BioId,
                        _ => _.EmployeeInformationMaster.InternalId,
                        _ => _timeZoneConverter.Convert(_.EmployeeInformationMaster.Doc, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _.EmployeeInformationMaster.Name,
                        _ => _.EmployeeInformationMaster.ForH,
                        _ => _timeZoneConverter.Convert(_.EmployeeInformationMaster.Dob, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _.EmployeeInformationMaster.PresentAddress,
                        _ => _.EmployeeInformationMaster.PermanentAddress,
                        _ => _.EmployeeInformationMaster.Gender,
                        _ => _.EmployeeInformationMaster.ContactNo,
                        _ => _.EmployeeInformationMaster.AltContactNo,
                        _ => _.EmployeeInformationMaster.MaritalStatus,
                        _ => _.EmployeeInformationMaster.NoOfDependents,
                        _ => _timeZoneConverter.Convert(_.EmployeeInformationMaster.ConfirmationDate, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _timeZoneConverter.Convert(_.EmployeeInformationMaster.DOJ, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _.EmployeeInformationMaster.IhExp,
                        _ => _.EmployeeInformationMaster.TotalExp,
                        _ => _.EmployeeInformationMaster.PfNo,
                        _ => _.EmployeeInformationMaster.EsiNo,
                        _ => _.EmployeeInformationMaster.AcNo,
                        _ => _.EmployeeInformationMaster.PpNo,
                        _ => _.EmployeeInformationMaster.PAN,
                        _ => _.EmployeeInformationMaster.BG,
                        _ => _.EmployeeInformationMaster.CL,
                        _ => _.EmployeeInformationMaster.EL,
                        _ => _.EmployeeInformationMaster.SL,
                        _ => _.EmployeeInformationMaster.BasicSalary,
                        _ => _.EmployeeInformationMaster.DA,
                        _ => _.EmployeeInformationMaster.HRA,
                        _ => _.EmployeeInformationMaster.Conveyance,
                        _ => _.EmployeeInformationMaster.Incentive,
                        _ => _.EmployeeInformationMaster.MedicalAllowance,
                        _ => _.EmployeeInformationMaster.OtherAllowances,
                        _ => _.EmployeeInformationMaster.TotalSalary,
                        _ => _.EmployeeInformationMaster.Photo,
                        _ => _.EmployeeInformationMaster.UanNo,
                        _ => _.EmployeeInformationMaster.IsActive,
                        _ => _.EmployeeInformationMaster.EmployeementUnder,
                        _ => _.EmployeeInformationMaster.Division,
                        _ => _.EmployeeInformationMaster.ContractorId,
                        _ => _.EmployeeInformationMaster.MessBill,
                        _ => _.EmployeeInformationMaster.Onroll,
                        _ => _.EmployeeInformationMaster.NameInTelugu,
                        _ => _timeZoneConverter.Convert(_.EmployeeInformationMaster.RjDate, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _.EmployeeInformationMaster.Document,
                        _ => _.EmployeeInformationMaster.Extension
                        );

                    for (var i = 1; i <= employeeInformationMasters.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[4], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(4); for (var i = 1; i <= employeeInformationMasters.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[7], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(7); for (var i = 1; i <= employeeInformationMasters.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[15], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(15); for (var i = 1; i <= employeeInformationMasters.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[16], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(16); for (var i = 1; i <= employeeInformationMasters.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[45], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(45);
                });
        }
    }
}