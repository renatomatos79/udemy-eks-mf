using PoliceStationsApi.Model.Db;
using PoliceStationsApi.Model.Settings;
using PoliceStationsApi.Repository.Mongo;

namespace PoliceStationsApi.Repository
{
    public class VehicleRepository : MongoDbRepository<VehicleDBModel>
    {
        public VehicleRepository(IDbSettngs dbSettings) :base(dbSettings, "vehicles") { }
    }
}
