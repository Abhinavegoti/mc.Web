using System.Collections.Generic;
using mc.Authorization.Users.Dto;
using mc.Dto;

namespace mc.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}