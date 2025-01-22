namespace Portfolio.RepositoryPattern.Shared;

public interface IRepository<TEntity> where TEntity : IEntity
{
    IQueryable<TEntity> Query();
    public Task<TEntity> Get(string id);
    public Task Add(TEntity book);
    public Task Update(TEntity book);
    public Task Delete(string id);
}
