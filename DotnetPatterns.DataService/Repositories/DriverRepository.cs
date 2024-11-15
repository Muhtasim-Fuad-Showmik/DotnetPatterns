using DotnetPatterns.DataService.Data;
using DotnetPatterns.DataService.Repositories.Interfaces;
using DotnetPatterns.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DotnetPatterns.DataService.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(AppDbContext context, ILogger logger) : base(context, logger) { }

    public override async Task<IEnumerable<Driver>> All()
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
            Logger.LogError(e, message: "{Repo} All function error", typeof(DriverRepository));
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
            Logger.LogError(e, message: "{Repo} Delete function error", typeof(DriverRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Driver driver)
    {
        try
        {
            // Get my entity
            var result = await DbSet.FirstOrDefaultAsync(x => x.Id == driver.Id);

            if (result == null)
                return false;

            result.UpdatedDate = DateTime.UtcNow;
            result.DriverNumber = driver.DriverNumber;
            result.FirstName = driver.FirstName;
            result.LastName = driver.LastName;
            result.DateOfBirth = driver.DateOfBirth;

            return true;
        }
        catch (Exception e)
        {
            Logger.LogError(e, message: "{Repo} Update function error", typeof(DriverRepository));
            throw;
        }
    }
}