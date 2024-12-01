namespace ServiceRequests.PoliceStations.Api.Model.Request.Vehicle
{
    public class VehicleCreateRequestModel
    {
        public required string PoliceStationId { get; set; }
        public required string VehicleType { get; set; }
        public required string VehicleLicensePlate { get; set; }
        public required int Mileage { get; set; }
        public required string FuelType { get; set; }
        public required int FuelAvailable { get; set; }
        public required int FuelCapacity { get; set; }
    }
}
