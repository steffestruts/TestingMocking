using MainApp.Interfaces;
using MainApp.Models;
using MainApp.Services;
using Moq;

namespace MainApp.Tests.Services;

public class ProductService_Tests
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly ProductService _productService;

    public ProductService_Tests()
    {
        _productServiceMock = new Mock<IProductService>();
        _productService = new ProductService();
    }

    [Fact]
    public void CreateProduct_ShouldReturnTrue_WhenProductIsCreated()
    {
        // arrange
        var productRegistrationForm = new ProductRegistrationForm { Title = "Test Product", Price = 100 };
        _productServiceMock
            .Setup(ps => ps.CreateProduct(productRegistrationForm))
            .Returns(true);

        // act
        var result = _productServiceMock.Object.CreateProduct(productRegistrationForm);

        // assert
        Assert.True(result);
        _productServiceMock.Verify(ps => ps.CreateProduct(productRegistrationForm), Times.Once);
    }

    [Fact]
    public void GetProduct_ShouldReturnListOfProducts() 
    {
        // Arrange
        var products = new List<Product>()
        {
            new() { Id = 1, Title = "Test Product 1", Price = 100 },
            new() { Id = 2, Title = "Test Product 2", Price = 200 }
        };

        _productServiceMock.Setup(ps => ps.GetProducts()).Returns(products);

        // Act
        var result = _productServiceMock.Object.GetProducts();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Equal("Test Product 1", result.First().Title);
    }

    [Fact]
    public void AddProduct_ShouldReturnTrue_AndListCountOfOne() 
    {
        // Arrange
        Product product = new () { Id = 1, Title = "Test Product 1", Price = 100 };

        // Act
        bool result = _productService.AddProductToList(product);

        // Assert
        Assert.True(result);
        Assert.Single(_productService.GetProducts());
    }
}
