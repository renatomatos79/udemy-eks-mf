namespace UsersApi.Model
{
    public class UserCreateRequestModel
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
