﻿namespace EnglishTrainer.ApplicationCore.Interfaces
{
    public interface IRepository <T> where T : class
    {
        IQueryable<T> Get();
    }
}
