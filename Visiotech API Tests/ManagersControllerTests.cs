using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Visiotech_API.Controllers;
using Visiotech_API.Services;

public class ManagersControllerTests
{
    private readonly ManagersController _controller;
    private readonly Mock<ILogger<ManagersController>> _mockLogger;
    private readonly Mock<IVisiotechService> _mockService;

    public ManagersControllerTests()
    {
        _mockService = new Mock<IVisiotechService>();
        _mockLogger = new Mock<ILogger<ManagersController>>();
        _controller = new ManagersController(_mockService.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task GetManagerIds_ShouldReturn_ManagerIdentifiers()
    {
        // Arrange
        var mockIds = new List<string> { "132254524", "143618668", "78903228" };
        _mockService.Setup(service => service.GetManagerIds())
            .ReturnsAsync(mockIds);

        // Act
        var result = await _controller.GetManagerIds();
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var ids = Assert.IsAssignableFrom<List<string>>(okResult.Value);

        // Assert
        Assert.NotNull(ids);
        Assert.Equal(3, ids.Count);
        Assert.Contains("132254524", ids);
        Assert.Contains("143618668", ids);
        Assert.Contains("78903228", ids);
    }

    [Fact]
    public async Task GetManagerIds_ShouldReturn_NoContent_WhenNoData()
    {
        // Arrange
        _mockService.Setup(service => service.GetManagerIds())
            .ReturnsAsync((List<string>)null);

        // Act
        var result = await _controller.GetManagerIds();

        // Assert
        Assert.IsType<NoContentResult>(result.Result);
    }

    [Fact]
    public async Task GetManagerIds_ShouldReturn_InternalServerError_OnException()
    {
        // Arrange
        _mockService.Setup(service => service.GetManagerIds())
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await _controller.GetManagerIds();
        var statusCodeResult = Assert.IsType<StatusCodeResult>(result.Result);

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }

    [Fact]
    public async Task GetManagersTaxNumbersSorted_ShouldReturn_TaxNumbersSorted()
    {
        // Arrange
        var mockTaxNumbers = new List<string> { "132254524", "143618668", "78903228" };
        _mockService.Setup(service => service.GetManagersTaxNumbersSorted(true))
            .ReturnsAsync(mockTaxNumbers);

        // Act
        var result = await _controller.GetManagersTaxNumbersSorted(true);
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var taxNumbers = Assert.IsAssignableFrom<List<string>>(okResult.Value);

        // Assert
        Assert.NotNull(taxNumbers);
        Assert.Equal(3, taxNumbers.Count);
        Assert.Equal("132254524", taxNumbers[0]);
        Assert.Equal("143618668", taxNumbers[1]);
        Assert.Equal("78903228", taxNumbers[2]);
    }

    [Fact]
    public async Task GetManagersTaxNumbersSorted_ShouldReturn_NoContent_WhenNoData()
    {
        // Arrange
        _mockService.Setup(service => service.GetManagersTaxNumbersSorted(true))
            .ReturnsAsync((List<string>)null);

        // Act
        var result = await _controller.GetManagersTaxNumbersSorted(true);

        // Assert
        Assert.IsType<NoContentResult>(result.Result);
    }

    [Fact]
    public async Task GetManagersTaxNumbersSorted_ShouldReturn_InternalServerError_OnException()
    {
        // Arrange
        _mockService.Setup(service => service.GetManagersTaxNumbersSorted(true))
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await _controller.GetManagersTaxNumbersSorted(true);
        var statusCodeResult = Assert.IsType<StatusCodeResult>(result.Result);

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
}
