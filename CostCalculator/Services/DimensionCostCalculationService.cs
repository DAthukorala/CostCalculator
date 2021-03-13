using CostCalculator.Core.Contracts;
using CostCalculator.Core.Models;
using CostCalculator.Repository.Services.Interfaces;

namespace CostCalculator.Core.Services
{
    public class DimensionCostCalculationService : ICostCalculator
    {
        private readonly IDimensionService _dimensionRepository;
        private readonly IDimensionCostServices _dimensionCostRepository;

        public DimensionCostCalculationService(IDimensionService dimensionRepository, IDimensionCostServices dimensionCostRepository)
        {
            _dimensionRepository = dimensionRepository;
            _dimensionCostRepository = dimensionCostRepository;
        }

        public decimal Calculate(Order order)
        {
            decimal fullCost = 0;
            foreach (var item in order.Items)
            {
                var category = _dimensionRepository.GetType(item.Width, item.Height, item.Depth);
                var categoryCost = _dimensionCostRepository.GetByType(category);
                item.Cost = categoryCost;
                fullCost += categoryCost;
            }
            order.Cost = fullCost;
            return fullCost;
        }
    }
}
