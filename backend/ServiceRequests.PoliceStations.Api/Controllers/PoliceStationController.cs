using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ServiceRequests.PoliceStations.Api.Model.Db;
using ServiceRequests.PoliceStations.Api.Repository;
using ServiceRequests.Common.Helpers;
using ServiceRequests.PoliceStations.Api.Model.Request.PoliceStation;

namespace ServiceRequests.PoliceStations.Api.Controllers;

[ApiController]
[Route("api/police-stations")]
public class PoliceStationController : ControllerBase
{
    private readonly ILogger<PoliceStationController> _logger;
    private readonly PoliceStationRepository _policeStationRepository;

    public PoliceStationController(ILogger<PoliceStationController> logger, PoliceStationRepository userRepository)
    {
        _logger = logger;
        _policeStationRepository = userRepository;
    }

    [HttpGet]
    public async Task<IResult> GetAll()
    {
        return await Task.FromResult(Results.Ok(_policeStationRepository.GetAll().Select(s => s.ToResponseModel())));
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetById(string id)
    {
        var _id = ConvertHelper.StringToGuid(id);
        if (_id is null)
        {
            return await Task.FromResult(Results.BadRequest("Invalid ID"));
        }

        var user = _policeStationRepository.GetById(_id.Value);
        if (user == null)
        {
            return await Task.FromResult(Results.NotFound());
        }

        return await Task.FromResult(Results.Ok(user.ToResponseModel()));
    }

    [HttpPost]
    public async Task<IResult> Create([FromBody] PoliceStationCreateRequestModel request)
    {
        var db = PoliceStationDBModel.FromCreateRequestModel(request);
        var id = _policeStationRepository.Insert(db);
        return await Task.FromResult(Results.Ok(_policeStationRepository.GetById(id)));
    }

    [HttpPut("{id}")]
    public async Task<IResult> Update(string id, [FromBody] PoliceStationUpdateRequestModel request)
    {
        var _id = ConvertHelper.StringToGuid(id);
        if (_id is null)
        {
            return await Task.FromResult(Results.BadRequest("Invalid ID"));
        }

        var user = _policeStationRepository.GetById(_id.Value);
        if (user == null)
        {
            return await Task.FromResult(Results.NotFound());
        }

        user.Name = request.Name;
        user.Latitute = request.Latitute;
        user.Longitude = request.Longitude;
        _policeStationRepository.Update(user);
            
        return await Task.FromResult(Results.Ok(user.ToResponseModel()));
    }

       
    [HttpPatch("{id}")]
    public async Task<IResult> PatchUser(string id, [FromBody] JsonPatchDocument<PoliceStationPatchRequestModel> patchDoc)
    {
        var _id = ConvertHelper.StringToGuid(id);
        if (_id is null)
        {
            return await Task.FromResult(Results.BadRequest("Invalid ID"));
        }

        var user = _policeStationRepository.GetById(_id.Value);
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
            _policeStationRepository.Update(user.ApplyPatch(userPatch));
        }
        catch (Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException)
        {
            var error = "Path operator has only support to \"add, remove, replace, move, copy, test\" and can only be applied on: Roles, IsActive and ImageUrl fields";
            return await Task.FromResult(Results.BadRequest(error));
        }          
            
        return await Task.FromResult(Results.Ok(user.ToResponseModel()));
    }        
}