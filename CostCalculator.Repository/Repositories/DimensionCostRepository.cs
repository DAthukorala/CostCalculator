using CostCalculator.Repository.Contracts;
using CostCalculator.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CostCalculator.Repository.Repositories
{
    public class DimensionCostRepository : IReadOnlyRepository<DimensionCost>
    {
        private readonly IQueryable<DimensionCost> _db = new List<DimensionCost> {
            new DimensionCost{ Type="small", Cost= 3},
            new DimensionCost{ Type="medium",Cost= 8},
            new DimensionCost{ Type="large",Cost= 15},
            new DimensionCost{ Type="xl",Cost= 25}
            }.AsQueryable();


        public List<DimensionCost> Find(Expression<Func<DimensionCost, bool>> filter = null)
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
