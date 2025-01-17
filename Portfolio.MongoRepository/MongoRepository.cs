﻿using MongoDB.Driver;
using Portfolio.RepositoryPattern;
using Portfolio.RepositoryPattern.Exceptions;

namespace Portfolio.MongoRepository;
public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
{
    private readonly IMongoDatabase _db;
    private readonly IMongoCollection<TEntity> _collection;

    public MongoRepository(IMongoClient client)
    {
        _db = client.GetDatabase("library");
        _collection = _db.GetCollection<TEntity>("books");
    }


    public async Task<TEntity> Get(string id)
    {
        var result = await _collection.FindAsync(x => x.Id == id);
        var entity = result.SingleOrDefault();

        if (entity == null)
        {
            throw new RepositoryNotFoundException("Not found");
        }

        return entity;
    }

    public IQueryable<TEntity> Query()
    {
        return _collection.AsQueryable();
    }


    public async Task Add(TEntity book)
    {
        try
        {
            await _collection.InsertOneAsync(book);
        }
        catch (MongoWriteException e)
        {
            if (e.WriteError.Category == ServerErrorCategory.DuplicateKey)
            {
                throw new RepositoryConflictException("Conflict", e);
            }
        }
    }

    public async Task Delete(string id)
    {
        var result = await _collection.DeleteOneAsync(x => x.Id == id);
        
        if (result.DeletedCount == 0)
        {
            throw new RepositoryNotFoundException("Not found");
        }
    }

    public async Task Update(TEntity book)
    {
        var result = await _collection.ReplaceOneAsync(x => x.Id == book.Id, book);

        if (result.ModifiedCount == 0)
        {
            throw new RepositoryNotFoundException("Not found");

        }

    }
}
