using PoliceStationsApi.Model.Db;
using PoliceStationsApi.Model.Settings;
using PoliceStationsApi.Repository.Mongo;

namespace PoliceStationsApi.Repository
{
    public class PoliceStationRepository : MongoDbRepository<PoliceStationDBModel>
    {
        public PoliceStationRepository(IDbSettngs dbSettings) :base(dbSettings, "police_stations") { }
    }
}
