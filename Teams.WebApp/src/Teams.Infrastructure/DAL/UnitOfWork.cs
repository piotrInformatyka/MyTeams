
using Teams.Domain.Repositories;

namespace Teams.Infrastructure.DAL;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly TeamDbContext _dbcontext;

    public UnitOfWork(TeamDbContext context)
    {
        _dbcontext = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbcontext.SaveChangesAsync();
    }
}
