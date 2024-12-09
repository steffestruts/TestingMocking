using MainApp.Interfaces;
using MainApp.Models;

namespace MainApp.Services;

public class ProductService : IProductService
{
    private List<Product> _products = [];

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
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetProducts()

    {
        return _products;
    }
}
