using Microsoft.AspNetCore.Mvc;
using UsersApi.Helpers;
using UsersApi.Model;
using UsersApi.Model.Db;
using UsersApi.Repository;

namespace UsersApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserRepository _userRepository;

        public UserController(ILogger<UserController> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet("users/")]
        public async Task<IResult> GetAll()
        {
            return await Task.FromResult(Results.Ok(_userRepository.GetAll().Select(s => s.ToResponseModel())));
        }

        [HttpGet("users/{id}")]
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

        [HttpPost("users/")]
        public async Task<IResult> Create([FromBody] UserCreateRequestModel request)
        {
            var db = UserDBModel.FromCreateRequestModel(request);
            var id = _userRepository.Insert(db);
            return await Task.FromResult(Results.Ok(_userRepository.GetById(id)));
        }

        [HttpPut("users/{id}")]
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

        [HttpDelete("users/{id}")]
        public async Task<IResult> Delete(string id)
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

            _userRepository.Delete(user);

            return await Task.FromResult(Results.NoContent());
        }
    }
}
