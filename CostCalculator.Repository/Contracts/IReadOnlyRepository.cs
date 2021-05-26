using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CostCalculator.Repository.Contracts
{
    public interface IReadOnlyRepository<T> where T : class
    {
        List<T> Find(Expression<Func<T, bool>> filter = null);
    }
}
