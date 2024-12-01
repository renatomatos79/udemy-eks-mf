using PoliceStationsApi.Model.Request;
using PoliceStationsApi.Model.Response;

namespace PoliceStationsApi.Model.Db
{
    public class PoliceStationDBModel : EntityBase
    {
        public required string Name { get; set; }
        public required float Latitute { get; set; }
        public required float Longitude { get; set; }
        public required bool IsActive { get; set; }

        public PoliceStationResponseModel ToResponseModel()
        {
            return new PoliceStationResponseModel
            {
                Id = Id.ToString(),
                Name = Name,
                Latitute = Latitute,
                Longitude = Longitude,
                IsActive = IsActive
            };
        }

        public PoliceStationPatchRequestModel ToUserPatch()
        {
            return new PoliceStationPatchRequestModel
            {
                IsActive = this.IsActive
            };
        }

        public PoliceStationDBModel ApplyPatch(PoliceStationPatchRequestModel request)
        {
            if (request.IsActive.HasValue)
            {
                this.IsActive = request.IsActive.Value;
            }

            return this;
        }

        public static PoliceStationDBModel FromCreateRequestModel(PoliceStationCreateRequestModel request)
        {
            return new PoliceStationDBModel
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Latitute = request.Latitute,
                Longitude = request.Longitude,
                IsActive = true,
            };
        }
    }
}
