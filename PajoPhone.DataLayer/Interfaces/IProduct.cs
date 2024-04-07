using PajoPhone.DataLayer;
namespace PajoPhone.DataLayer.Interfaces;

public interface IProduct
{
    IEnumerable<Datalayer.Models.Product> GetAllProducts();
    IEnumerable<Datalayer.Models.Product> FilterProducts(string name, decimal maxPrice, decimal minPrice,List<int>categoriesId,List<string> fields);
    Datalayer.Models.Product GetById(int id);
    int CreateProduct(Datalayer.Models.Product product);
    void UpdateProduct(Datalayer.Models.Product newProduct);
    bool ExistProduct(string productName);
    int GetIdByName(string productName);
}
