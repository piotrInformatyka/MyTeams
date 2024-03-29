﻿using Teams.Domain.Entities;

namespace Teams.Domain.Repositories;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAllAsync();
    Task<Team?> GetTeamAsync(Guid id);
}
