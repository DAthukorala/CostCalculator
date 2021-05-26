using CostCalculator.Repository.Contracts;
using CostCalculator.Repository.Models;
using CostCalculator.Repository.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CostCalculator.Repository.Services.Implementations
{
    public class DimensionCostServices : IDimensionCostServices
    {
        private IReadOnlyRepository<DimensionCost> _repository;

        public DimensionCostServices(IReadOnlyRepository<DimensionCost> repository)
        {
            _repository = repository;
        }

        public IEnumerable<DimensionCost> GetAll()
        {
            return _repository.Find();
        }

        public decimal GetByType(string type)
        {
            return _repository.Find(x => x.Type == type).First().Cost;
        }
    }
}
