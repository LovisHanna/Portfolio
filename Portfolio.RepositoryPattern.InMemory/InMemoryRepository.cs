using Portfolio.RepositoryPattern.Shared;
using Portfolio.RepositoryPattern.Shared.Exceptions;

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

        throw new NotFoundException("Not found");
    }

    public IQueryable<TEntity> Query()
    {

        return _entities.Values.AsQueryable();
    }

    public Task Add(TEntity entity)
    {
        if (_entities.ContainsKey(entity.Id))
        {
            throw new ConflictException("Conflict");
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
            throw new NotFoundException("Not found");
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
            throw new NotFoundException("Not found");
        }
        return Task.CompletedTask;
    }
}
