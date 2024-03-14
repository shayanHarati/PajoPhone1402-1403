using PajoPhone.DataLayer;
namespace PajoPhone.DataLayer.Interfaces;

public interface IProduct
{
    IEnumerable<Datalayer.Models.Product> GetAllProducts();
    IEnumerable<Datalayer.Models.Product> FilterProducts(string name, decimal maxPrice, decimal minPrice);
    Datalayer.Models.Product GetById(int id);
    void CreateProduct(Datalayer.Models.Product product);
    void UpdateProduct(Datalayer.Models.Product newProduct);
}
