namespace UsersApi.Model.Request
{
    public class UserPatchRequestModel
    {
        public string? Roles { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsActive { get; set; }
    }
}
