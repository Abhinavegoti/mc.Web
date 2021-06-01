using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using mc.Authorization.Users;
using mc.MultiTenancy;

namespace mc.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}