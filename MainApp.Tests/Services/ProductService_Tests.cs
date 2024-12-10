using MainApp.Interfaces;
using MainApp.Models;
using MainApp.Services;
using Moq;

namespace MainApp.Tests.Services;

public class ProductService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IProductService _productService;

    public ProductService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _productService = new ProductService(_fileServiceMock.Object);
    }

    [Fact]
    public void CreateProduct_ShouldAddProductToList_AndSaveToFile() 
    {
        // Arrange
        var productRegistrationForm = new ProductRegistrationForm();
        _fileServiceMock
            .Setup(fs => fs.SaveContentToFile(It.IsAny<string>()))
            .Returns(true);
        // Act
        var result = _productService.CreateProduct(productRegistrationForm);
        // Assert
        Assert.True(result);
        _fileServiceMock.Verify(fs => fs.SaveContentToFile(It.IsAny<string>()), Times.Once);
    }
}
