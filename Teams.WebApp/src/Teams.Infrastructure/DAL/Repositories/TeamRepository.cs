using Microsoft.EntityFrameworkCore;
using Teams.Domain.Entities;
using Teams.Domain.Repositories;

namespace Teams.Infrastructure.DAL.Repositories;

internal sealed class TeamRepository : ITeamRepository
{
    private readonly TeamDbContext _dbContext;

    public TeamRepository(TeamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Team>> GetAllAsync() => await _dbContext.Teams.Include(x => x.Members).ToListAsync();
}
