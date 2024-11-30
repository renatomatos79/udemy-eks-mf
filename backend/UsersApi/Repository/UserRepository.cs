using UsersApi.Model.Db;
using UsersApi.Model.Settings;
using UsersApi.Repository.Mongo;

namespace UsersApi.Repository
{
    public class UserRepository : MongoDbRepository<UserDBModel>
    {
        public UserRepository(IDbSettngs dbSettings) :base(dbSettings, "users") { }
    }
}
