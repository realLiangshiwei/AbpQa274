using AbpQa274.MyUsers;
using AbpQa274.Users;
using AutoMapper;

namespace AbpQa274
{
    public class AbpQa274ApplicationAutoMapperProfile : Profile
    {
        public AbpQa274ApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<MyUserCreateDto, AppUser>();
            CreateMap<AppUser, MyUserDto>();
            CreateMap<MyUserUpdateDto, AppUser>();
        }
    }
}
