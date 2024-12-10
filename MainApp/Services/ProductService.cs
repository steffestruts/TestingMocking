using MainApp.Interfaces;
using MainApp.Models;
using System.Text.Json;

namespace MainApp.Services;

public class ProductService : IProductService
{
    private readonly IFileService _fileService;
    private List<Product> _products;

    public ProductService(IFileService fileService)
    {
        _fileService = fileService;
        _products = new List<Product>();
    }

    public bool AddProductToList(Product product)
    {
        try
        {
            _products.Add(product);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool CreateProduct(ProductRegistrationForm form)
    {
        try
        {
            var product = new Product { Title = form.Title, Price = form.Price };
            _products.Add(product);

            var json = JsonSerializer.Serialize(_products);
            _fileService.SaveContentToFile(json);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<Product> GetProducts()
    {
        try
        {
            var json = _fileService.GetContentFromFile();
            _products = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
            return _products;
        }
        catch
        {
            return new List<Product>();
        }
    }
}
