using CostCalculator.Repository.Models;
using System.Collections.Generic;

namespace CostCalculator.Repository.Services.Interfaces
{
    public interface IDimensionCostServices
    {
        IEnumerable<DimensionCost> GetAll();
        decimal GetByType(string type);
    }
}
