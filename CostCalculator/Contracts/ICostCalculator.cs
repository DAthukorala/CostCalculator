using CostCalculator.Core.Models;

namespace CostCalculator.Core.Contracts
{
    internal interface ICostCalculator
    {
        decimal Calculate(Order order);
    }
}
