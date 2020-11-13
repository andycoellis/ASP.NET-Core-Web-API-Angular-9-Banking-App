using System;
using System.Collections.Generic;
using System.Linq.Expressions;

/*
    This Repository Pattern was inspired by a tutorial from Programming with Mosh
    https://www.youtube.com/watch?v=rtXpYpZdOzM&t=991s

    It goes further than standard Design Pattern taught in tutorials as such the tutorial from
    Mosh has served as a strict template for our implementation of the Repository Pattern 
 */

namespace WDT2020_a3.Services.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        //These methods allow us to use generics on our model and db context
        //We are able to use a function<> in the argument to utilise lambas
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}
