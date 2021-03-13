using CostCalculator.Repository.Models;
using System.Collections.Generic;

namespace CostCalculator.Repository.Services.Interfaces
{
    public interface IDimensionService
    {
        List<Dimension> GetAll();
        string GetType(decimal width, decimal height, decimal depth);
    }
}
