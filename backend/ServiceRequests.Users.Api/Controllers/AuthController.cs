using Microsoft.AspNetCore.Mvc;
using ServiceRequests.Common.Services;
using ServiceRequests.Users.Api.Constants;
using ServiceRequests.Users.Api.Model.Request.Token;
using ServiceRequests.Users.Api.Model.Response.Token;
using ServiceRequests.Users.Api.Repository;

namespace ServiceRequests.Users.Api.Controllers;

[ApiController]
[Route("api/token")]
public class AuthController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly ITokenService _tokenService;    
    private readonly UserRepository _userRepository;

    public AuthController(ILogger<UserController> logger, ITokenService tokenService, UserRepository userRepository)
    {
        _logger = logger;
        _tokenService = tokenService;
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<IResult> Token([FromBody] TokenRequestModel request)
    {
        if (request == null || !request.IsValid())
        {
            return await Task.FromResult(Results.BadRequest("Request is not valid"));
        }

        var user = _userRepository.GetByEmail(request.Email);
        if (user == null || !user.IsActive || user.IsBlocked)
        {
            return await Task.FromResult(Results.Unauthorized());
        }
        
        if (user.Password != request.Password)
        {
            user.TokenErrorCount++;
            user.IsBlocked = user.TokenErrorCount > TokenConstants.MAX_ERROR_COUNT;
            _userRepository.Update(user);
            return await Task.FromResult(Results.Unauthorized());
        }

        // restart token error count
        user.TokenErrorCount = 0;
        _userRepository.Update(user);

        var response = user.ToResponseModel();
        var token = _tokenService.GenerateToken(response.Id, response.Name, String.Join(',', response.Roles));
        return await Task.FromResult(Results.Ok(new TokenResponseModel { Name = response.Name, Token = token }));
    }
}
