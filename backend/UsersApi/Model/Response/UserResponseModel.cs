using ServiceRequests.Common.Model.Response;

namespace UsersApi.Model.Response
{
    public class UserResponseModel : BaseResponseModel
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string[] Roles { get; set; }
        public required bool IsBlocked { get; set; }
        public required string ImageUrl { get; set; }
    }
}
