using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Tests.Domain
{
    public class SaleTests
    {
        [Fact]
        public void AddItem_Should_Apply_Discount_And_Add_Item()
        {
            // Arrange
            var sale = new Sale();
            var item = new SaleItem
            {
                ProductId = "p1",
                ProductName = "Beer",
                Quantity = 5,
                UnitPrice = 10
            };

            // Act
            sale.AddItem(item);

            // Assert
            sale.Items.Should().HaveCount(1);
            item.Discount.Should().Be(5); // 10 * 5 * 10% = 5
            item.TotalPrice.Should().Be(45); // (10 * 5) - 5
        }

        [Fact]
        public void AddItem_Should_Throw_When_Quantity_Exceeds_Limit()
        {
            // Arrange
            var sale = new Sale();
            var item = new SaleItem
            {
                ProductId = "p1",
                ProductName = "Big Order",
                Quantity = 21,
                UnitPrice = 15
            };

            // Act
            Action act = () => sale.AddItem(item);

            // Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("You can't sell more than 20 identical items.");
        }

        [Fact]
        public void TotalAmount_Should_Calculate_Sum_Of_Item_Prices()
        {
            // Arrange
            var sale = new Sale();
            sale.AddItem(new SaleItem { ProductId = "a", ProductName = "A", Quantity = 2, UnitPrice = 50 }); // no discount
            sale.AddItem(new SaleItem { ProductId = "b", ProductName = "B", Quantity = 10, UnitPrice = 20 }); // 20% discount

            // Act
            var total = sale.TotalAmount;

            // Assert
            total.Should().Be(100 + 160); // 2*50 + (10*20)*0.8
        }

        [Fact]
        public async Task PublishEventAsync_Should_Not_Throw()
        {
            // Arrange
            var sale = new Sale { Id = Guid.NewGuid() };

            // Act
            var act = async () => await sale.PublishEventAsync("TestEvent");

            // Assert
            await act.Should().NotThrowAsync();
        }
    }
}
