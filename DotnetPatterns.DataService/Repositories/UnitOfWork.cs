using DotnetPatterns.DataService.Data;
using DotnetPatterns.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace DotnetPatterns.DataService.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context;
    
    public IDriverRepository Drivers { get; set; }
    public IAchievementsRepository Achievements { get; set; }

    public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        var logger = loggerFactory.CreateLogger("logs");

        Drivers = new DriverRepository(_context, logger);
        Achievements = new AchievementsRepository(_context, logger);
    }

    public async Task<bool> CompleteAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
        
    }
}