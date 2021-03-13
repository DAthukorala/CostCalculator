using CostCalculator.Repository.Contracts;
using CostCalculator.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CostCalculator.Repository.Repositories
{
    public class DimensionRepository : IReadOnlyRepository<Dimension>
    {
        private readonly IQueryable<Dimension> _db = new List<Dimension> {
            new Dimension{Type= "small", MinSize=1, MaxSize=9 },
            new Dimension{Type= "medium", MinSize=10, MaxSize=49 },
            new Dimension{Type= "large", MinSize=50, MaxSize=99 },
            new Dimension{Type= "xl", MinSize=100, MaxSize=1000 }
            }.AsQueryable();


        public List<Dimension> Find(Expression<Func<Dimension, bool>> filter = null)
        {
            if (filter != null)
            {
                return _db.Where(filter).ToList();
            }
            else
            {
                return _db.ToList();
            }
        }
    }
}
