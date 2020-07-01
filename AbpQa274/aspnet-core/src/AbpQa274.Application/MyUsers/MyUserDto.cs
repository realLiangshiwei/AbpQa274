using System;
using Volo.Abp.Application.Dtos;

namespace AbpQa274.MyUsers
{
    public class MyUserDto : FullAuditedEntityDto<Guid>
    {

        public string DisplayName { get; set; }

    }
}
