using ServiceRequests.PoliceStations.Api.Model.Db;
using ServiceRequests.Common.Model.Response;
using ServiceRequests.PoliceStations.Api.Model.Response.PoliceStation;

namespace ServiceRequests.PoliceStations.Api.Model.Response.Vehicle
{
    public class VehicleResponseModel : BaseResponseModel
    {
        public required PoliceStationResponseModel PoliceStation { get; set; }
        public required string VehicleType { get; set; }
        public required string VehicleLicensePlate { get; set; }
        public required int Mileage { get; set; }
        public required string FuelType { get; set; }
        public required int FuelAvailable { get; set; }
        public required int FuelCapacity { get; set; }
        public required float Latitude { get; set; }
        public required float Longitude { get; set; }
        public required bool IsBroken { get; set; }
    }
}
