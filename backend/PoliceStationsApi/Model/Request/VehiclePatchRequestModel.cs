namespace PoliceStationsApi.Model.Request
{
    public class VehiclePatchRequestModel
    {
        public int? Mileage { get; set; }
        public int? FuelAvailable { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBroken { get; set; }
    }
}
