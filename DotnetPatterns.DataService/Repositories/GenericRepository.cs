using DotnetPatterns.DataService.Data;
using DotnetPatterns.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DotnetPatterns.DataService.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public readonly ILogger Logger;
    protected AppDbContext Context;
    internal DbSet<T> DbSet;

    public GenericRepository(AppDbContext context, ILogger logger)
    {
        Context = context;
        Logger = logger;
        
        DbSet = context.Set<T>();
    }
    
    public Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public async Task<T?> GetById(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<bool> Add(T entity)
    {
        await DbSet.AddAsync(entity);
        return true;
    }

    public Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}