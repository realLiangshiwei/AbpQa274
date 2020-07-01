using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbpQa274.Users;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpQa274.MyUsers
{
    public class MyUserAppService : ApplicationService, IMyUserAppService
    {
        private readonly IMyUserRepository _myUserRepository;

        public MyUserAppService(IMyUserRepository myUserRepository)
        {
            _myUserRepository = myUserRepository;
        }

        public virtual async Task<PagedResultDto<MyUserDto>> GetListAsync(GetMyUsersInput input)
        {

            var totalCount = await _myUserRepository.GetCountAsync(input.FilterText, input.DisplayName);
            var items = await _myUserRepository.GetListAsync(input.FilterText, input.DisplayName, input.Sorting,
                input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<MyUserDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AppUser>, List<MyUserDto>>(items)
            };
        }

        public virtual async Task<MyUserDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<AppUser, MyUserDto>(await _myUserRepository.GetAsync(id));
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _myUserRepository.DeleteAsync(id);
        }

        public virtual async Task<MyUserDto> CreateAsync(MyUserCreateDto input)
        {
            var newMyUser = ObjectMapper.Map<MyUserCreateDto, AppUser>(input);
            newMyUser.TenantId = CurrentTenant.Id;
            var myUser = await _myUserRepository.InsertAsync(newMyUser);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<AppUser, MyUserDto>(myUser);
        }

        public virtual async Task<MyUserDto> UpdateAsync(Guid id, MyUserUpdateDto input)
        {
            var myUser = await _myUserRepository.GetAsync(id);
            ObjectMapper.Map(input, myUser);
            var updatedMyUser = await _myUserRepository.UpdateAsync(myUser);
            return ObjectMapper.Map<AppUser, MyUserDto>(updatedMyUser);
        }
    }

    public interface IMyUserAppService : IApplicationService
    {
        Task<PagedResultDto<MyUserDto>> GetListAsync(GetMyUsersInput input);

        Task<MyUserDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<MyUserDto> CreateAsync(MyUserCreateDto input);

        Task<MyUserDto> UpdateAsync(Guid id, MyUserUpdateDto input);
    }
}
