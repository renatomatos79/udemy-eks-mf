using ServiceRequests.Common.Model.Db;
using ServiceRequests.PoliceStations.Api.Helpers;
using ServiceRequests.PoliceStations.Api.Model.Request.Vehicle;
using ServiceRequests.PoliceStations.Api.Model.Response.Vehicle;

namespace ServiceRequests.PoliceStations.Api.Model.Db;

public class VehicleDBModel : EntityBase
{
    public required PoliceStationDBModel PoliceStation { get; set; }
    public required string VehicleType { get; set; }
    public required string VehicleLicensePlate { get; set; }
    public required int Mileage { get; set; }
    public required string FuelType { get; set; }
    public required int FuelAvailable { get; set; }
    public required int FuelCapacity { get; set; }
    public required float Latitude { get; set; }
    public required float Longitude { get; set; }
    public required bool IsActive { get; set; }
    public required bool IsBroken { get; set; }

    public VehicleResponseModel ToResponseModel()
    {
        return new VehicleResponseModel
        {
            Id = Id.ToString(),
            PoliceStation = this.PoliceStation.ToResponseModel(),
            VehicleType = VehicleType,
            VehicleLicensePlate = VehicleLicensePlate,
            Mileage = Mileage,
            FuelType = FuelType,
            FuelAvailable = FuelAvailable,
            FuelCapacity = FuelCapacity,
            Latitude = Latitude,
            Longitude = Longitude,
            IsActive = IsActive,
            IsBroken = IsBroken
        };
    }

    public VehiclePatchRequestModel ToVehiclePatch()
    {
        return new VehiclePatchRequestModel
        {
            Mileage = this.Mileage,
            FuelAvailable = this.FuelAvailable,
            Latitude = this.Latitude,
            Longitude = this.Longitude,
            IsActive = this.IsActive,
            IsBroken = this.IsBroken
        };
    }

    public VehicleDBModel ApplyPatch(VehiclePatchRequestModel request)
    {
        if (request.Mileage.HasValue)
        {
            this.Mileage = request.Mileage.Value;
        }

        if (request.FuelAvailable.HasValue)
        {
            this.FuelAvailable = request.FuelAvailable.Value;
        }

        if (request.Latitude.HasValue)
        {
            this.Latitude = request.Latitude.Value;
        }

        if (request.Longitude.HasValue)
        {
            this.Longitude = request.Longitude.Value;
        }

        if (request.IsActive.HasValue)
        {
            this.IsActive = request.IsActive.Value;
        }

        if (request.IsBroken.HasValue)
        {
            this.IsActive = request.IsBroken.Value;
        }

        return this;
    }

    public static VehicleDBModel FromCreateRequestModel(PoliceStationDBModel policeStation, VehicleCreateRequestModel request)
    {
        return new VehicleDBModel
        {
            Id = Guid.NewGuid(),
            PoliceStation = policeStation,
            VehicleType = VehicleTypeEnumHelper.FromString(request.VehicleType).ToString(),
            VehicleLicensePlate = request.VehicleLicensePlate,
            Mileage = request.Mileage,
            FuelType = FuelTypeEnumHelper.FromString(request.FuelType).ToString(),
            FuelAvailable = request.FuelAvailable,
            FuelCapacity = request.FuelCapacity,
            Latitude = 0,
            Longitude = 0,
            IsActive = true,
            IsBroken = false
        };
    }
}
