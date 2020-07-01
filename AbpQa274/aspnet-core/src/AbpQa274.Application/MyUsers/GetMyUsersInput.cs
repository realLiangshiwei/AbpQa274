using Volo.Abp.Application.Dtos;

namespace AbpQa274.MyUsers
{
    public class GetMyUsersInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string DisplayName { get; set; }

        public GetMyUsersInput()
        {

        }
    }
}
