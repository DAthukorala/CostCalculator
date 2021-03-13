using CostCalculator.Core.Models;

namespace CostCalculator.Core.Contracts
{
    public interface ICostCalculator
    {
        decimal Calculate(Order order);
    }
}
