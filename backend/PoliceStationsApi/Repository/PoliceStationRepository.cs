using PoliceStationsApi.Model.Db;
using ServiceRequests.Common.Model.Settings;
using ServiceRequests.Common.Repository.Mongo;

namespace PoliceStationsApi.Repository
{
    public class PoliceStationRepository : MongoDbRepository<PoliceStationDBModel>
    {
        public PoliceStationRepository(IDbSettngs dbSettings) :base(dbSettings, "police_stations") { }
    }
}
