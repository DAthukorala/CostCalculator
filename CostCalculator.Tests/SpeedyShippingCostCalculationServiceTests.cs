﻿using CostCalculator.Core.Models;
using CostCalculator.Core.Services;
using CostCalculator.Repository.Contracts;
using CostCalculator.Repository.Models;
using CostCalculator.Repository.Services.Implementations;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CostCalculator.Tests
{
    [TestFixture]
    public class SpeedyShippingCostCalculationServiceTests
    {
        [Test]
        public void Calculate_SmallItem_ReturnDoubleTheSmallCost([Values(0, -1, 1, 5, 9)] decimal dimension)
        {
            var fakeDimensionData = new List<Dimension> { new Dimension { Type = "small", MinSize = 1, MaxSize = 9 } };
            var fakeCostData = new List<DimensionCost> { new DimensionCost { Type = "small", Cost = 3 } };
            var dimensionCostCalculationService = GetFakeDimensionCostCalculationService(fakeDimensionData, fakeCostData);
            var speedyShippingCostCalculationService = new SpeedyShippingCostCalculationService(dimensionCostCalculationService);
            var order = new Order { Items = new List<OrderItem> { new OrderItem { Height = dimension, Width = dimension, Depth = dimension } } };

            var cost = speedyShippingCostCalculationService.Calculate(order);

            using (new AssertionScope())
            {
                cost.Should().Be(6);
                order.Cost.Should().Be(3);
                order.Items[0].Cost.Should().Be(3);
            }
        }

        [Test]
        public void Calculate_MediumItem_ReturnDoubleTheMediumCost([Values(0, -1, 1, 5, 9)] decimal dimension)
        {
            var fakeDimensionData = new List<Dimension> { new Dimension { Type = "medium", MinSize = 10, MaxSize = 49 } };
            var fakeCostData = new List<DimensionCost> { new DimensionCost { Type = "medium", Cost = 8 } };
            var dimensionCostCalculationService = GetFakeDimensionCostCalculationService(fakeDimensionData, fakeCostData);
            var speedyShippingCostCalculationService = new SpeedyShippingCostCalculationService(dimensionCostCalculationService);
            var order = new Order { Items = new List<OrderItem> { new OrderItem { Height = dimension, Width = dimension, Depth = dimension } } };

            var cost = speedyShippingCostCalculationService.Calculate(order);

            using (new AssertionScope())
            {
                cost.Should().Be(16);
                order.Cost.Should().Be(8);
                order.Items[0].Cost.Should().Be(8);
            }
        }

        [Test]
        public void Calculate_LargeItem_ReturnDoubleTheLargeCost([Values(0, -1, 1, 5, 9)] decimal dimension)
        {
            var fakeDimensionData = new List<Dimension> { new Dimension { Type = "large", MinSize = 50, MaxSize = 99 } };
            var fakeCostData = new List<DimensionCost> { new DimensionCost { Type = "large", Cost = 15 } };
            var dimensionCostCalculationService = GetFakeDimensionCostCalculationService(fakeDimensionData, fakeCostData);
            var speedyShippingCostCalculationService = new SpeedyShippingCostCalculationService(dimensionCostCalculationService);
            var order = new Order { Items = new List<OrderItem> { new OrderItem { Height = dimension, Width = dimension, Depth = dimension } } };

            var cost = speedyShippingCostCalculationService.Calculate(order);

            using (new AssertionScope())
            {
                cost.Should().Be(30);
                order.Cost.Should().Be(15);
                order.Items[0].Cost.Should().Be(15);
            }
        }

        [Test]
        public void Calculate_ExtraLargeItem_ReturnDoubleTheExtraLargeCost([Values(0, -1, 1, 5, 9)] decimal dimension)
        {
            var fakeDimensionData = new List<Dimension> { new Dimension { Type = "xl", MinSize = 100, MaxSize = 1000 } };
            var fakeCostData = new List<DimensionCost> { new DimensionCost { Type = "xl", Cost = 25 } };
            var dimensionCostCalculationService = GetFakeDimensionCostCalculationService(fakeDimensionData, fakeCostData);
            var speedyShippingCostCalculationService = new SpeedyShippingCostCalculationService(dimensionCostCalculationService);
            var order = new Order { Items = new List<OrderItem> { new OrderItem { Height = dimension, Width = dimension, Depth = dimension } } };

            var cost = speedyShippingCostCalculationService.Calculate(order);

            using (new AssertionScope())
            {
                cost.Should().Be(50);
                order.Cost.Should().Be(25);
                order.Items[0].Cost.Should().Be(25);
            }
        }

        private DimensionCostCalculationService GetFakeDimensionCostCalculationService(List<Dimension> dimensionData, List<DimensionCost> costData)
        {
            var mockDimensionRepository = new Mock<IReadOnlyRepository<Dimension>>();
            mockDimensionRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Dimension, bool>>>()))
                .Returns(dimensionData);
            var mockDimensionService = new DimensionService(mockDimensionRepository.Object);

            var mockDimensionCostRepository = new Mock<IReadOnlyRepository<DimensionCost>>();
            mockDimensionCostRepository.Setup(x => x.Find(It.IsAny<Expression<Func<DimensionCost, bool>>>()))
                .Returns(costData);
            var mockDimensionCostServices = new DimensionCostServices(mockDimensionCostRepository.Object);

            var service = new DimensionCostCalculationService(mockDimensionService, mockDimensionCostServices);
            return service;
        }
    }
}
