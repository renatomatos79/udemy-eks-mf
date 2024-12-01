namespace PoliceStationsApi.Helpers
{
    public static class ConvertHelper
    {
        public static Guid? StringToGuid(string id)
        {
            Guid _id;
            if (Guid.TryParse(id, out _id))
            {
                return _id;
            }
            return null;
        }
    }
}
