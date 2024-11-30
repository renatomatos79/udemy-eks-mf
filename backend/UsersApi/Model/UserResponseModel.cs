namespace UsersApi.Model
{
    public class UserResponseModel
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
