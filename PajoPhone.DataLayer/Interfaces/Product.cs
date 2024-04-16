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

    private List<Datalayer.Models.Product> _filterCategories(List<int>categoriesId)
    {
        List<Datalayer.Models.Product> selectedProduct3 = new List<Datalayer.Models.Product>();
        foreach (var category in categoriesId)
        {
            var selectedList= _context.Products.Where(c => c.CategoryId == category).ToList();
            foreach (var product in selectedList)
            {
                selectedProduct3.Add(product);
            }
        }

        return selectedProduct3;
    }
    public IEnumerable<Datalayer.Models.Product> FilterProducts(string name, decimal maxPrice, decimal minPrice,List<int>categoriesId,List<string> fields)
    {
        var selectedProduct= _context.Products.Where(c => c.ProductName.Contains(name)).ToList();
        var selectedProduct2 = _context.Products.Where(c => c.ProductPrice <= maxPrice && c.ProductPrice >= minPrice).ToList();
        var selectedProduct3 = _filterCategories(categoriesId).ToList();
        List<Datalayer.Models.Product> selectedProduct4 = new List<Datalayer.Models.Product>();
        List<int> categoriesIds = new List<int>();
        foreach (var field in fields)
        {
            var selectedFields= _context.Fields.Where(c => c.FieldTitle == field).ToList();
            foreach (var selectedField in selectedFields)
            {
                categoriesIds.Add(selectedField.CategoryId);
            }
            
        }
        selectedProduct4= _filterCategories(categoriesIds.Distinct().ToList()).ToList();
        if (selectedProduct.Count()==0)
        {
            if ((selectedProduct3.Union(selectedProduct4)).Count()==0 && categoriesId.Count()==0 && fields.Count()==0)
            {
                return selectedProduct2.ToList();
            }
            else
            {
                var result = selectedProduct2.Intersect(selectedProduct3.Union(selectedProduct4));
                return result.ToList();
            }
        }
        else
        {
            if ((selectedProduct3.Union(selectedProduct4)).Count()==0 && categoriesIds.Count()==0 && fields.Count()==0)
            {
                return selectedProduct.Intersect(selectedProduct2).ToList();
            }
            else
            {
                return (selectedProduct3.Union(selectedProduct4)).Intersect(selectedProduct)
                    .Intersect(selectedProduct2).ToList();
            }
        }
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

    public int GetIdByName(string productName)
    {
        return _context.Products.SingleOrDefault(c => c.ProductName == productName).Id;
    }
}