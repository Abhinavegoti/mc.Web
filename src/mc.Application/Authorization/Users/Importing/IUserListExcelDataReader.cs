using System.Collections.Generic;
using mc.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace mc.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
