using System.Collections.Generic;

namespace CostCalculator.Core.Models
{
    public class Order
    {
        public List<OrderItem> Items { get; set; }
        public decimal Cost { get; set; }
    }
}
