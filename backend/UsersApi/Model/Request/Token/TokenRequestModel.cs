namespace ServiceRequests.Users.Api.Model.Request.Token;

public class TokenRequestModel
{
    public required string Email { get; set; }
    public required string Password { get; set; }

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
    }
}