using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpQa274.Users
{
    public interface IMyUserRepository : IRepository<AppUser, Guid>
    {
        Task<List<AppUser>> GetListAsync(
            string filterText = null,
            string displayName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string displayName = null,
            CancellationToken cancellationToken = default);
    }
}
