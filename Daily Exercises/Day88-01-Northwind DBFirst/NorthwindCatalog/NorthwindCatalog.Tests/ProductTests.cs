using NorthwindCatalog.Services.DTOs;

namespace NorthwindCatalog.Tests
{
    public class ProductTests
    {
        [Fact]
        public void InventoryValue_Should_Return_Correct_Value()
        {
            // Arrange
            var product = new ProductDto
            {
                ProductName = "Chai",
                UnitPrice = 20,
                UnitsInStock = 10
            };

            // Act
            var result = product.InventoryValue;

            // Assert
            Assert.Equal(200, result);
        }

        [Fact]
        public void InventoryValue_Should_Return_Zero_When_Stock_Is_Zero()
        {
            // Arrange
            var product = new ProductDto
            {
                ProductName = "Chang",
                UnitPrice = 50,
                UnitsInStock = 0
            };

            // Act
            var result = product.InventoryValue;

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void InventoryValue_Should_Return_Zero_When_UnitPrice_Is_Zero()
        {
            // Arrange
            var product = new ProductDto
            {
                ProductName = "Aniseed Syrup",
                UnitPrice = 0,
                UnitsInStock = 25
            };

            // Act
            var result = product.InventoryValue;

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void InventoryValue_Should_Handle_Large_Values_Correctly()
        {
            // Arrange
            var product = new ProductDto
            {
                ProductName = "Chef Anton's Gumbo Mix",
                UnitPrice = 150,
                UnitsInStock = 100
            };

            // Act
            var result = product.InventoryValue;

            // Assert
            Assert.Equal(15000, result);
        }
    }
}