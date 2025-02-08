using Microsoft.Extensions.Configuration;
using Moq;
using Rectangle.API.Models;
using Rectangle.API.Services;
using Rectangle.API.Utils.Contracts;
using System.Text.Json;

namespace Rectangle.Tests.Services
{
    public class RectangleServiceTests
    {
        private readonly Mock<IFileStorageUtil> _fileStorageUtilMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly RectangleService _rectangleService;
        private readonly string _filePath = "testfile.json";

        public RectangleServiceTests()
        {
            _fileStorageUtilMock = new Mock<IFileStorageUtil>();
            _configurationMock = new Mock<IConfiguration>();
            _configurationMock.Setup(config => config["RecfangleFilePath"]).Returns(_filePath);
            _rectangleService = new RectangleService(_configurationMock.Object, _fileStorageUtilMock.Object);
        }

        [Fact]
        public async Task GetRectangleAsync_ShouldReturnRectangle()
        {
            // Arrange
            var expectedRectangle = new RectangleDTO { Width = 100, Height = 50 };
            var json = JsonSerializer.Serialize(expectedRectangle);
            _fileStorageUtilMock.Setup(util => util.ReadFromFileAsync(_filePath, It.IsAny<CancellationToken>()))
                                .ReturnsAsync(json);

            // Act
            var result = await _rectangleService.GetRectangleAsync(CancellationToken.None);

            // Assert
            Assert.Equal(expectedRectangle.Width, result.Width);
            Assert.Equal(expectedRectangle.Height, result.Height);
        }

        [Fact]
        public async Task UpdateRectangleAsync_ShouldWriteRectangleToFile()
        {
            // Arrange
            var rectangle = new RectangleDTO { Width = 100, Height = 50 };
            var json = JsonSerializer.Serialize(rectangle);

            // Act
            await _rectangleService.UpdateRectangleAsync(rectangle, CancellationToken.None);

            // Assert
            _fileStorageUtilMock.Verify(util => util.WriteToFileAsync(_filePath, json, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
