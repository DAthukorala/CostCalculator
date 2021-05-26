using CostCalculator.Repository.Contracts;
using CostCalculator.Repository.Models;
using CostCalculator.Repository.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CostCalculator.Repository.Services.Implementations
{
    public class DimensionService : IDimensionService
    {
        private IReadOnlyRepository<Dimension> _repository;

        public DimensionService(IReadOnlyRepository<Dimension> repository)
        {
            _repository = repository;
        }

        public List<Dimension> GetAll()
        {
            return _repository.Find();
        }

        public string GetType(decimal width, decimal height, decimal depth)
        {
            return _repository.Find(d =>
            (width >= d.MinSize && width <= d.MaxSize) &&
            (height >= d.MinSize && height <= d.MaxSize) &&
            (depth >= d.MinSize && depth <= d.MaxSize)).First().Type;
        }
    }
}
