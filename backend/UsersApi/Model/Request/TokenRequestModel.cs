namespace UsersApi.Model.Request;

public class TokenRequestModel
{
    public required string Email { get; set; }
    public required string Password { get; set; }

    public bool IsValid() 
    {
        return !string.IsNullOrEmpty(this.Email) && !string.IsNullOrEmpty(this.Password);
    }
}