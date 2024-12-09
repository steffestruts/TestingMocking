using MainApp.Interfaces;
using Moq;

namespace MainApp.Tests.Services;

public class ProductService_Tests
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly IProductService _productService;

    public ProductService_Tests()
    {
        _productServiceMock = new Mock<IProductService>();
        _productService = _productServiceMock.Object;
    }

    [Fact]
    public void CreateProduct_ShouldReturnTrue_WhenProductIsCreated()
    {
        // arrange

        // act

        // assert
    }
}
