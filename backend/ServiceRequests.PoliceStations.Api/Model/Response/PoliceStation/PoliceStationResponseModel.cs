using ServiceRequests.Common.Model.Response;

namespace ServiceRequests.PoliceStations.Api.Model.Response.PoliceStation
{
    public class PoliceStationResponseModel : BaseResponseModel
    {
        public required string Name { get; set; }
        public required float Latitute { get; set; }
        public required float Longitude { get; set; }
    }
}
