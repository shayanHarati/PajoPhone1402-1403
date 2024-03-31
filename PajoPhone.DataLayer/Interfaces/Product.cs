namespace PajoPhone.DataLayer.Interfaces;

public class Product:IProduct
{
    private readonly Context _context;

    public Product(Context context)
    {
        _context = context;
    }
    public IEnumerable<Datalayer.Models.Product> GetAllProducts()
    {
        return _context.Products;
    }

    public IEnumerable<Datalayer.Models.Product> FilterProducts(string name, decimal maxPrice, decimal minPrice)
    {
        var selectedProduct= _context.Products.Where(c => c.ProductName.Contains(name));
        var selectdProduct2 = _context.Products.Where(c => c.ProductPrice <= maxPrice && c.ProductPrice >= minPrice);
        if (selectdProduct2 == null || selectedProduct == null)
        {
            return selectedProduct.Union(selectdProduct2);
        }

        return selectedProduct.Intersect(selectdProduct2);
    }

    public Datalayer.Models.Product GetById(int id)
    {
        return _context.Products.SingleOrDefault(c=>c.Id == id);
    }

    public int CreateProduct(Datalayer.Models.Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return _context.Products.Single(c => c.ProductName == product.ProductName).Id;
    }

    public void UpdateProduct(Datalayer.Models.Product newProduct)
    {
        _context.Products.Update(newProduct);
        _context.SaveChanges();

    }

    public bool ExistProduct(string productName)
    {
        return _context.Products.Any(c => c.ProductName == productName);
    }
}