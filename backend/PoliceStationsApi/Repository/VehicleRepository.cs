using PoliceStationsApi.Model.Db;
using ServiceRequests.Common.Model.Settings;
using ServiceRequests.Common.Repository.Mongo;

namespace PoliceStationsApi.Repository
{
    public class VehicleRepository : MongoDbRepository<VehicleDBModel>
    {
        public VehicleRepository(IDbSettngs dbSettings) :base(dbSettings, "vehicles") { }
    }
}
