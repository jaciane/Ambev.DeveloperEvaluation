using Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    public class CreateSaleValidatorTests
    {
        private readonly CreateSaleValidator _validator = new();

        [Fact]
        public void Should_Pass_Validation_For_Valid_Command()
        {
            // Arrange
            var command = new CreateSaleCommand
            {
                CustomerId = "cust-001",
                CustomerName = "Alice",
                BranchId = "br-001",
                BranchName = "Main Branch",
                Items = new List<CreateSaleItem>
                {
                    new CreateSaleItem
                    {
                        ProductId = "prod-001",
                        ProductName = "Beer",
                        Quantity = 2,
                        UnitPrice = 10.5m
                    }
                }
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Should_Fail_Validation_When_Fields_Are_Missing()
        {
            // Arrange
            var command = new CreateSaleCommand();

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "CustomerId");
            result.Errors.Should().Contain(e => e.PropertyName == "CustomerName");
            result.Errors.Should().Contain(e => e.PropertyName == "BranchId");
            result.Errors.Should().Contain(e => e.PropertyName == "BranchName");
            result.Errors.Should().Contain(e => e.PropertyName == "Items");
        }

        [Fact]
        public void Should_Fail_Validation_When_Item_Fields_Are_Invalid()
        {
            // Arrange
            var command = new CreateSaleCommand
            {
                CustomerId = "cust-002",
                CustomerName = "Bob",
                BranchId = "br-002",
                BranchName = "Branch B",
                Items = new List<CreateSaleItem>
                {
                    new CreateSaleItem
                    {
                        ProductId = "",
                        ProductName = "",
                        Quantity = 0,
                        UnitPrice = 0
                    }
                }
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName.Contains("ProductId"));
            result.Errors.Should().Contain(e => e.PropertyName.Contains("ProductName"));
            result.Errors.Should().Contain(e => e.PropertyName.Contains("Quantity"));
            result.Errors.Should().Contain(e => e.PropertyName.Contains("UnitPrice"));
        }

        [Fact]
        public void Should_Fail_When_Too_Many_Items_Of_Same_Product()
        {
            var command = new CreateSaleCommand
            {
                CustomerId = "cust-003",
                CustomerName = "Charlie",
                BranchId = "br-003",
                BranchName = "Branch C",
                Items = new List<CreateSaleItem>
                {
                    new CreateSaleItem
                    {
                        ProductId = "prod-003",
                        ProductName = "Whisky",
                        Quantity = 21, // Invalid (over limit)
                        UnitPrice = 50
                    }
                }
            };

            var result = _validator.Validate(command);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e =>
                e.PropertyName.Contains("Quantity") &&
                e.ErrorMessage.Contains("You can't sell more than 20 identical items"));
        }
    }
}

