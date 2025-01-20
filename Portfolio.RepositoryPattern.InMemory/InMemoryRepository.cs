 using Portfolio.RepositoryPattern.Exceptions;
using Portfolio.RepositoryPattern.Shared;

namespace Portfolio.RepositoryPattern.InMemory;

public class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
{
    Dictionary<string, TEntity> _entities;

    public InMemoryRepository()
    {
        _entities = new Dictionary<string, TEntity>();
    }

    public Task<TEntity> Get(string id)
    {
        if (_entities.ContainsKey(id))
        {
            return Task.FromResult(_entities[id]);
        }

        throw new RepositoryNotFoundException("Not found");
    }

    public IQueryable<TEntity> Query()
    {

        return _entities.Values.AsQueryable();
    }

    public Task Add(TEntity entity)
    {
        if (_entities.ContainsKey(entity.Id))
        {
            throw new RepositoryConflictException("Conflict");
        }
        _entities.Add(entity.Id, entity);
        return Task.CompletedTask;
    }

    public Task Update(TEntity entity)
    {
        if (_entities.ContainsKey(entity.Id))
        {
            _entities[entity.Id] = entity;
        }
        else
        {
            throw new RepositoryNotFoundException("Not found");
        }
        return Task.CompletedTask;
    }

    public Task Delete(string id)
    {
        if (_entities.ContainsKey(id))
        {
            _entities.Remove(id);
        }
        else
        {
            throw new RepositoryNotFoundException("Not found");
        }
        return Task.CompletedTask;
    }
}
