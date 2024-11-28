using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using eShop.Basket.API.Model;

namespace eShop.Basket.API.Tests.Model
{
    [TestClass]
    public class BasketItemTest
    {
        [TestMethod]
        public void Validate_ShouldReturnError_WhenQuantityIsLessThan1()
        {
            // Arrange
            var basketItem = new BasketItem { Quantity = 0 };

            // Act
            var results = basketItem.Validate(new ValidationContext(basketItem));

            // Assert
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Invalid number of units", results.First().ErrorMessage);
        }

        [TestMethod]
        public void Validate_ShouldReturnError_WhenQuantityIsGreaterThanOrEqualTo42()
        {
            // Arrange
            var basketItem = new BasketItem { Quantity = 42 };

            // Act
            var results = basketItem.Validate(new ValidationContext(basketItem));

            // Assert
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Quantity must be less than 42", results.First().ErrorMessage);
        }

        [TestMethod]
        public void Validate_ShouldNotReturnError_WhenQuantityIsWithinValidRange()
        {
            // Arrange
            var basketItem = new BasketItem { Quantity = 10 };

            // Act
            var results = basketItem.Validate(new ValidationContext(basketItem));

            // Assert
            Assert.AreEqual(0, results.Count());
        }

         [TestMethod]
        public void Validate_ShouldReturnError_WhenQuantityIsNotDivisibleBy6()
        {
            // Arrange
            var basketItem = new BasketItem { Quantity = 7 };

            // Act
            var results = basketItem.Validate(new ValidationContext(basketItem));

            // Assert
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Quantity must be divisible by 6", results.First().ErrorMessage);
        }

        [TestMethod]
        public void Validate_ShouldNotReturnError_WhenQuantityIsDivisibleBy6()
        {
            // Arrange
            var basketItem = new BasketItem { Quantity = 12 };

            // Act
            var results = basketItem.Validate(new ValidationContext(basketItem));

            // Assert
            Assert.AreEqual(0, results.Count());
        }
    }
}