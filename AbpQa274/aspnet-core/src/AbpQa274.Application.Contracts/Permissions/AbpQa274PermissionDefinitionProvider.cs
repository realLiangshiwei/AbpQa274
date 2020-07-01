using AbpQa274.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpQa274.Permissions
{
    public class AbpQa274PermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpQa274Permissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpQa274Permissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpQa274Resource>(name);
        }
    }
}
