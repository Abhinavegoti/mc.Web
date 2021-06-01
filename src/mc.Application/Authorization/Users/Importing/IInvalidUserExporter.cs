using System.Collections.Generic;
using mc.Authorization.Users.Importing.Dto;
using mc.Dto;

namespace mc.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
