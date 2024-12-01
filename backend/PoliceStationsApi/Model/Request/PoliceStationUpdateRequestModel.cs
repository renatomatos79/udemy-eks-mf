namespace PoliceStationsApi.Model.Request
{
    public class PoliceStationUpdateRequestModel
    {
        public required string Name { get; set; }
        public required float Latitute { get; set; }
        public required float Longitude { get; set; }
    }
}
