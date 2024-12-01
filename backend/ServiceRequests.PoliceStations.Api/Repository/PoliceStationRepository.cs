using ServiceRequests.PoliceStations.Api.Model.Db;
using ServiceRequests.Common.Model.Settings;
using ServiceRequests.Common.Repository.Mongo;

namespace ServiceRequests.PoliceStations.Api.Repository
{
    public class PoliceStationRepository : MongoDbRepository<PoliceStationDBModel>
    {
        public PoliceStationRepository(IDbSettngs dbSettings) :base(dbSettings, "police_stations") { }
    }
}
