namespace PoliceStationsApi.Model.Response
{
    public class PoliceStationResponseModel : BaseResponseModel
    {
        public required string Name { get; set; }
        public required float Latitute { get; set; }
        public required float Longitude { get; set; }
    }
}
