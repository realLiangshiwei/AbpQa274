using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbpQa274.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Settings;
using Volo.Abp.Threading;
using Volo.Abp.Uow;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace AbpQa274
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IdentityUserManager))]
    public class ConcurrencyIdentityUserManager : IdentityUserManager
    {
        private readonly IMyUserRepository _myUserRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ConcurrencyIdentityUserManager(
            IdentityUserStore store,
            IIdentityRoleRepository roleRepository,
            IIdentityUserRepository userRepository,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<IdentityUser> passwordHasher,
            IEnumerable<IUserValidator<IdentityUser>> userValidators,
            IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<ConcurrencyIdentityUserManager> logger,
            ISettingProvider settingProvider,
            ICancellationTokenProvider cancellationTokenProvider,
            IOrganizationUnitRepository organizationUnitRepository,
            IMyUserRepository myUserRepository,
            IUnitOfWorkManager unitOfWorkManager) : base(
            store,
            roleRepository,
            userRepository,
            optionsAccessor,
            passwordHasher,
            userValidators,
            passwordValidators,
            keyNormalizer,
            errors,
            services,
            logger,
            cancellationTokenProvider,
            organizationUnitRepository,
            userRepository,
            settingProvider)
        {
            _myUserRepository = myUserRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public override async Task<IdentityResult> CreateAsync(IdentityUser user)
        {
            /* We want to update a customized user property after a user created.
             * But we lack with this code. I tried many UOW combination without luck.
             * Maybe you can help us.
             * You have to uncomment below codes.. */

            IdentityResult identityResult;
            try
            {
                // Create a user.
                identityResult = await base.CreateAsync(user);

                user.SetProperty("DisplayName", user.UserName);

            }
            // Can not catch any exception like this!
            catch (Exception e)
            {
                Console.WriteLine(e);
                identityResult = IdentityResult.Failed();
            }

            return identityResult;
        }
    }
}
