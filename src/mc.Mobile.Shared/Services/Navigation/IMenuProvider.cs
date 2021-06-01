using System.Collections.Generic;
using MvvmHelpers;
using mc.Models.NavigationMenu;

namespace mc.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}