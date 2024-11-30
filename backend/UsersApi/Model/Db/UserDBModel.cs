namespace UsersApi.Model.Db
{
    public class UserDBModel : EntityBase
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public UserDBModel() { }

        public UserResponseModel ToResponseModel()
        {
            return new UserResponseModel
            {
                Id = Id,
                Name = Name,
                Email = Email
            };
        }

        public static UserDBModel FromCreateRequestModel(UserCreateRequestModel request)
        {
            return new UserDBModel
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            };
        }
    }
}
