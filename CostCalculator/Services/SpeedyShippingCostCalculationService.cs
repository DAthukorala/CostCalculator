using CostCalculator.Core.Contracts;
using CostCalculator.Core.Models;

namespace CostCalculator.Core.Services
{
    public class SpeedyShippingCostCalculationService : ICostCalculator
    {
        private readonly ICostCalculator _calculator;

        public SpeedyShippingCostCalculationService(ICostCalculator calculator)
        {
            _calculator = calculator;
        }

        public decimal Calculate(Order order)
        {
            var cost = _calculator.Calculate(order);
            var speedyShippingCost = cost * 2;
            return speedyShippingCost;
        }
    }
}
