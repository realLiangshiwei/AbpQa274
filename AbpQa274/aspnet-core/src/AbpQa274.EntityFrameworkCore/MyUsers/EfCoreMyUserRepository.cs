using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using AbpQa274.EntityFrameworkCore;
using AbpQa274.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpQa274.MyUsers
{
    public class EfCoreMyUserRepository : EfCoreRepository<AbpQa274DbContext, AppUser, Guid>, IMyUserRepository
    {
        public EfCoreMyUserRepository(IDbContextProvider<AbpQa274DbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<AppUser>> GetListAsync(
            string filterText = null,
            string displayName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, displayName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? "DisplayName asc" : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string displayName = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, displayName);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<AppUser> ApplyFilter(
            IQueryable<AppUser> query,
            string filterText,
            string displayName = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.DisplayName.Contains(filterText))
                .WhereIf(!string.IsNullOrWhiteSpace(displayName), e => e.DisplayName.Contains(displayName));
        }
    }
}
