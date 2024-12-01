using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ServiceRequests.Common.Helpers;
using UsersApi.Model.Db;
using UsersApi.Model.Request;
using UsersApi.Repository;

namespace UsersApi.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserRepository _userRepository;

    public UserController(ILogger<UserController> logger, UserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IResult> GetAll()
    {
        return await Task.FromResult(Results.Ok(_userRepository.GetAll().Select(s => s.ToResponseModel())));
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetById(string id)
    {
        var _id = ConvertHelper.StringToGuid(id);
        if (_id is null)
        {
            return await Task.FromResult(Results.BadRequest("Invalid ID"));
        }

        var user = _userRepository.GetById(_id.Value);
        if (user == null)
        {
            return await Task.FromResult(Results.NotFound());
        }

        return await Task.FromResult(Results.Ok(user.ToResponseModel()));
    }

    [HttpPost]
    public async Task<IResult> Create([FromBody] UserCreateRequestModel request)
    {
        var db = UserDBModel.FromCreateRequestModel(request);
        var id = _userRepository.Insert(db);
        return await Task.FromResult(Results.Ok(_userRepository.GetById(id)));
    }

    [HttpPut("{id}")]
    public async Task<IResult> Update(string id, [FromBody] UserUpdateRequestModel request)
    {
        var _id = ConvertHelper.StringToGuid(id);
        if (_id is null)
        {
            return await Task.FromResult(Results.BadRequest("Invalid ID"));
        }

        var user = _userRepository.GetById(_id.Value);
        if (user == null)
        {
            return await Task.FromResult(Results.NotFound());
        }

        user.Email = request.Email;
        user.Name = request.Name;
        _userRepository.Update(user);
            
        return await Task.FromResult(Results.Ok(user.ToResponseModel()));
    }

       
    [HttpPatch("{id}")]
    public async Task<IResult> PatchUser(string id, [FromBody] JsonPatchDocument<UserPatchRequestModel> patchDoc)
    {
        var _id = ConvertHelper.StringToGuid(id);
        if (_id is null)
        {
            return await Task.FromResult(Results.BadRequest("Invalid ID"));
        }

        var user = _userRepository.GetById(_id.Value);
        if (user == null)
        {
            return await Task.FromResult(Results.NotFound());
        }

        // Apply patch request on temp object
        try
        {
            var userPatch = user.ToUserPatch();
            patchDoc.ApplyTo(userPatch);
                
            // updates DB
            _userRepository.Update(user.ApplyPatch(userPatch));
        }
        catch (Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException)
        {
            var error = "Path operator has only support to \"add, remove, replace, move, copy, test\" and can only be applied on: Roles, IsActive and ImageUrl fields";
            return await Task.FromResult(Results.BadRequest(error));
        }          
            
        return await Task.FromResult(Results.Ok(user.ToResponseModel()));
    }        
}