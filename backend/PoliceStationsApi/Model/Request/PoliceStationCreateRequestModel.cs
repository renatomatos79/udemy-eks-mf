namespace PoliceStationsApi.Model.Request
{
    public class PoliceStationCreateRequestModel
    {
        public required string Name { get; set; }
        public required float Latitute { get; set; }
        public required float Longitude { get; set; }
    }
}
