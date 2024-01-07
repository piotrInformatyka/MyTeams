﻿namespace Teams.Domain.Repositories;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync();
}
