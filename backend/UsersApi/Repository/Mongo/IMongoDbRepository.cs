using System.Linq.Expressions;
using UsersApi.Model.Db;

namespace UsersApi.Repository.Mongo
{
    public interface IMongoDbRepository<TEntity> where TEntity : EntityBase
    {
        Guid Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
