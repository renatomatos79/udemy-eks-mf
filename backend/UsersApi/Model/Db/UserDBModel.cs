using ServiceRequests.Common.Model.Db;
using ServiceRequests.Users.Api.Helpers;
using ServiceRequests.Users.Api.Model.Request.User;
using ServiceRequests.Users.Api.Model.Response.User;

namespace ServiceRequests.Users.Api.Model.Db;

public class UserDBModel : EntityBase
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string[] Roles { get; set; }
    public required bool IsActive { get; set; }
    public required bool IsBlocked { get; set; }
    public required string ImageUrl { get; set; }
    public required int TokenErrorCount { get; set; }

    public UserResponseModel ToResponseModel()
    {
        return new UserResponseModel
        {
            Id = Id.ToString(),
            Name = Name,
            Email = Email,
            Roles = Roles,
            IsBlocked = IsBlocked,
            IsActive = IsActive,
            ImageUrl = ImageUrl
        };
    }

    public UserPatchRequestModel ToUserPatch()
    {
        return new UserPatchRequestModel
        {
            ImageUrl = this.ImageUrl,
            Roles = String.Join(',', this.Roles),
            IsActive = this.IsActive
        };
    }

    public UserDBModel ApplyPatch(UserPatchRequestModel request)
    {
        if (!string.IsNullOrEmpty(request.Roles))
        {
            var roles = request.Roles.Split(',') ?? [];
            this.Roles = roles.Select(s => RolesEnumHelper.FromString(s).ToString()).ToArray();
        }

        if (!string.IsNullOrEmpty(request.ImageUrl))
        {
            this.ImageUrl = request.ImageUrl;
        }

        if (request.IsActive.HasValue)
        {
            this.IsActive = request.IsActive.Value;
            if (request.IsActive.Value) {
                this.IsBlocked = false;
                this.TokenErrorCount = 0;
            }
        }

        return this;
    }

    public static UserDBModel FromCreateRequestModel(UserCreateRequestModel request)
    {
        return new UserDBModel
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            Roles = request.Roles.Select(s => RolesEnumHelper.FromString(s).ToString()).ToArray(),
            IsBlocked = false,
            IsActive = true,
            ImageUrl = request.ImageUrl,
            TokenErrorCount = 0
        };
    }
}
