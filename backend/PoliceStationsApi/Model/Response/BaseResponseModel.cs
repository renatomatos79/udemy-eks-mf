namespace PoliceStationsApi.Model.Response
{
    public class BaseResponseModel
    {
        public required string Id { get; set; }
        public required bool IsActive { get; set; }
    }
}
