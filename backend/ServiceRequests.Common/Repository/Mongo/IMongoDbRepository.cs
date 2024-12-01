using ServiceRequests.Common.Model.Db;
using System.Linq.Expressions;

namespace ServiceRequests.Common.Repository.Mongo;

public interface IMongoDbRepository<TEntity> where TEntity : EntityBase
{
    Guid Insert(TEntity entity);
    bool Update(TEntity entity);
    bool Delete(TEntity entity);
    IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
    IEnumerable<TEntity> GetAll();
    TEntity GetById(Guid id);
}
