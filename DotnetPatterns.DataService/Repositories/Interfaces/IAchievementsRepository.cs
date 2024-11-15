using DotnetPatterns.Entities.DbSet;

namespace DotnetPatterns.DataService.Repositories.Interfaces;

public interface IAchievementsRepository : IGenericRepository<Achievement>
{
    Task<Achievement> GetDriverAchievementAsync(Guid driverId);
}