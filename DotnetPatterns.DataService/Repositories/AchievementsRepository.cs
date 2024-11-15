using DotnetPatterns.DataService.Data;
using DotnetPatterns.DataService.Repositories.Interfaces;
using DotnetPatterns.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DotnetPatterns.DataService.Repositories;

public class AchievementsRepository : GenericRepository<Achievement>, IAchievementsRepository
{
    public AchievementsRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
    {
        try
        {
            return await DbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
        }
        catch (Exception e)
        {
            Logger.LogError(e, message: "{Repo} GetDriverAchievementAsync function error", typeof(AchievementsRepository));
            throw;
        }
    }
    
    public override async Task<IEnumerable<Achievement>> All()
    {
        try
        {
            return await DbSet.Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Logger.LogError(e, message: "{Repo} All function error", typeof(AchievementsRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            // Get my entity
            var result = await DbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                return false;

            result.Status = 0;
            result.UpdatedDate = DateTime.UtcNow;

            return true;
        }
        catch (Exception e)
        {
            Logger.LogError(e, message: "{Repo} Delete function error", typeof(AchievementsRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Achievement achievement)
    {
        try
        {
            // Get my entity
            var result = await DbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);

            if (result == null)
                return false;

            result.UpdatedDate = DateTime.UtcNow;
            result.FastestLap = achievement.FastestLap;
            result.PolePosition = achievement.PolePosition;
            result.RaceWins = achievement.RaceWins;
            result.WorldChampionship = achievement.WorldChampionship;

            return true;
        }
        catch (Exception e)
        {
            Logger.LogError(e, message: "{Repo} Update function error", typeof(AchievementsRepository));
            throw;
        }
    }
}