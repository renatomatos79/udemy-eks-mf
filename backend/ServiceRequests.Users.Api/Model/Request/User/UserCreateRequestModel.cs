namespace ServiceRequests.Users.Api.Model.Request.User
{
    public class UserCreateRequestModel
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string[] Roles { get; set; }
        public required string ImageUrl { get; set; }
    }
}
