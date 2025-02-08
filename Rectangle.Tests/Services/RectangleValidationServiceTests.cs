using Rectangle.API.Models;
using Rectangle.API.Services;

namespace Rectangle.Tests.Services
{
    public class RectangleValidationServiceTests
    {
        private readonly RectangleValidationService _rectangleValidationService;

        public RectangleValidationServiceTests()
        {
            _rectangleValidationService = new RectangleValidationService();
        }

        [Fact]
        public async Task ValidateRectangleAsync_ShouldReturnError_WhenWidthExceedsHeight()
        {
            // Arrange
            var rectangle = new RectangleDTO { Width = 100, Height = 50 };

            // Act
            var result = await _rectangleValidationService.ValidateRectangleAsync(rectangle);

            // Assert
            Assert.Equal("Width cannot exceed height.", result);
        }

        [Fact]
        public async Task ValidateRectangleAsync_ShouldReturnNull_WhenWidthDoesNotExceedHeight()
        {
            // Arrange
            var rectangle = new RectangleDTO { Width = 50, Height = 100 };

            // Act
            var result = await _rectangleValidationService.ValidateRectangleAsync(rectangle);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task ValidateRectangleAsync_ShouldReturnNull_WhenWidthEqualsHeight()
        {
            // Arrange
            var rectangle = new RectangleDTO { Width = 100, Height = 100 };

            // Act
            var result = await _rectangleValidationService.ValidateRectangleAsync(rectangle);

            // Assert
            Assert.Null(result);
        }
    }
}

