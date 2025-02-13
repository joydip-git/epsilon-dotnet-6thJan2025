﻿namespace ProductManagementSystem.UserInterface.Models
{
    public interface IEpsilonDbRepository<T, TId>
    {
        List<T>? FetchAll();
        T? Fetch(TId id);
        T? Insert(T entity);
        T? Update(TId id, T entity);
        T? Delete(TId id);
    }
}
