using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PoliceStationsApi.Helpers;
using PoliceStationsApi.Model.Db;
using PoliceStationsApi.Model.Request;
using PoliceStationsApi.Repository;
using ServiceRequests.Common.Helpers;

namespace PoliceStationsApi.Controllers;

[ApiController]
[Route("api/vehicles")]
public class VehicleController : ControllerBase
{
    private readonly ILogger<VehicleController> _logger;
    private readonly PoliceStationRepository _policeStationRepository;
    private readonly VehicleRepository _vehicleRepository;

    public VehicleController(ILogger<VehicleController> logger, PoliceStationRepository userRepository, VehicleRepository vehicleRepository)
    {
        _logger = logger;
        _policeStationRepository = userRepository;
        _vehicleRepository = vehicleRepository;
    }

    [HttpGet]
    public async Task<IResult> GetAll()
    {
        return await Task.FromResult(Results.Ok(_vehicleRepository.GetAll().Select(s => s.ToResponseModel())));
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetById(string id)
    {
        var _id = ConvertHelper.StringToGuid(id);
        if (_id is null)
        {
            return await Task.FromResult(Results.BadRequest("Invalid ID"));
        }

        var vehicle = _vehicleRepository.GetById(_id.Value);
        if (vehicle == null)
        {
            return await Task.FromResult(Results.NotFound());
        }

        return await Task.FromResult(Results.Ok(vehicle.ToResponseModel()));
    }

    [HttpPost]
    public async Task<IResult> Create([FromBody] VehicleCreateRequestModel request)
    {
        var policeStationId = ConvertHelper.StringToGuid(request.PoliceStationId);
        if (policeStationId is null)
        {
            return await Task.FromResult(Results.BadRequest("Invalid PoliceStationId"));
        }

        var policeStation = _policeStationRepository.GetById(policeStationId.Value);
        if (policeStation is null)
        {
            return await Task.FromResult(Results.NotFound("PoliceStation not found"));
        }

        var db = VehicleDBModel.FromCreateRequestModel(policeStation, request);
        var id = _vehicleRepository.Insert(db);
        return await Task.FromResult(Results.Ok(_vehicleRepository.GetById(id)));
    }

    [HttpPut("{id}")]
    public async Task<IResult> Update(string id, [FromBody] VehicleUpdateRequestModel request)
    {
        var _id = ConvertHelper.StringToGuid(id);
        if (_id is null)
        {
            return await Task.FromResult(Results.BadRequest("Invalid ID"));
        }

        var vehicle = _vehicleRepository.GetById(_id.Value);
        if (vehicle == null)
        {
            return await Task.FromResult(Results.NotFound());
        }

        vehicle.VehicleType = VehicleTypeEnumHelper.FromString(request.VehicleType).ToString();
        vehicle.VehicleLicensePlate = request.VehicleLicensePlate;
        vehicle.Mileage = request.Mileage;
        vehicle.FuelType = FuelTypeEnumHelper.FromString(request.FuelType).ToString();
        vehicle.FuelAvailable = request.FuelAvailable;
        vehicle.FuelCapacity = request.FuelCapacity;

        _vehicleRepository.Update(vehicle);
            
        return await Task.FromResult(Results.Ok(vehicle.ToResponseModel()));
    }
       
    [HttpPatch("{id}")]
    public async Task<IResult> PatchVehicle(string id, [FromBody] JsonPatchDocument<VehiclePatchRequestModel> patchDoc)
    {
        var _id = ConvertHelper.StringToGuid(id);
        if (_id is null)
        {
            return await Task.FromResult(Results.BadRequest("Invalid ID"));
        }

        var vehicle = _vehicleRepository.GetById(_id.Value);
        if (vehicle == null)
        {
            return await Task.FromResult(Results.NotFound());
        }

        // Apply patch request on temp object
        try
        {
            var vehiclePatch = vehicle.ToVehiclePatch();
            patchDoc.ApplyTo(vehiclePatch);
                
            // updates DB
            _vehicleRepository.Update(vehicle.ApplyPatch(vehiclePatch));
        }
        catch (Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException)
        {
            var error = "Path operator has only support to \"add, remove, replace, move, copy, test\" and can only be applied on: Roles, IsActive and ImageUrl fields";
            return await Task.FromResult(Results.BadRequest(error));
        }          
            
        return await Task.FromResult(Results.Ok(vehicle.ToResponseModel()));
    }        
}