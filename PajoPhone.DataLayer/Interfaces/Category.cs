namespace PajoPhone.DataLayer.Interfaces;

public class Category:ICategory
{
    private Context _context;

    public Category(Context context)
    {
        _context = context;
    }
    public IEnumerable<Models.Category> GetAllCategories()
    {
        return _context.Category;
    }

    public void CreateCategory(Models.Category category)
    {
        _context.Category.Add(category);
        _context.SaveChanges();
    }

    public void UpdateCategory(Models.Category newCategory)
    {
        _context.Category.Update(newCategory);
        _context.SaveChanges();
    }
}