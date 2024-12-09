using MainApp.Models;

namespace MainApp.Interfaces;

public interface IProductService
{
    bool CreateProduct(ProductRegistrationForm form);
    IEnumerable<Product> GetProducts();
}
