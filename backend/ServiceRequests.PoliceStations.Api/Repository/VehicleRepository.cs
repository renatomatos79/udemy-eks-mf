using ServiceRequests.PoliceStations.Api.Model.Db;
using ServiceRequests.Common.Model.Settings;
using ServiceRequests.Common.Repository.Mongo;

namespace ServiceRequests.PoliceStations.Api.Repository
{
    public class VehicleRepository : MongoDbRepository<VehicleDBModel>
    {
        public VehicleRepository(IDbSettngs dbSettings) :base(dbSettings, "vehicles") { }
    }
}
