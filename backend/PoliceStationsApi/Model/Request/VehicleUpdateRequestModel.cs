namespace PoliceStationsApi.Model.Request
{
    public class VehicleUpdateRequestModel
    {
        public required string VehicleType { get; set; }
        public required string VehicleLicensePlate { get; set; }
        public required int Mileage { get; set; }
        public required string FuelType { get; set; }
        public required int FuelAvailable { get; set; }
        public required int FuelCapacity { get; set; }
    }
}
