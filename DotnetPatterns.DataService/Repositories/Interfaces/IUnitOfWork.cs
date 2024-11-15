namespace DotnetPatterns.DataService.Repositories.Interfaces;

public interface IUnitOfWork
{
    IDriverRepository Drivers { get; }
    IAchievementsRepository Achievements { get; }

    Task<bool> CompleteAsync();
}