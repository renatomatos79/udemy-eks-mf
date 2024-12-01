using ServiceRequests.Common.Model.Settings;
using ServiceRequests.Common.Repository.Mongo;
using ServiceRequests.Users.Api.Model.Db;

namespace ServiceRequests.Users.Api.Repository
{
    public class UserRepository : MongoDbRepository<UserDBModel>
    {
        public UserRepository(IDbSettngs dbSettings) :base(dbSettings, "users") { }

        public UserDBModel? GetByEmail(string email)
        {
            var search = Search(s => s.Email == email);
            if (!search.Any())
            {
                return null;
            }
            return search.FirstOrDefault();
        }
    }
}
