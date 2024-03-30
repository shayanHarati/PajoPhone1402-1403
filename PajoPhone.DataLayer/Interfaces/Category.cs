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

    public Models.Category GetCategory(int id)
    {
        return _context.Category.SingleOrDefault(c => c.Id == id);
    }

    public int GetLevel(int id)
    {
        return GetCategory(id).Level;
    }

    public int CreateCategory(Models.Category category)
    {
        _context.Category.Add(category);
        _context.SaveChanges();
        return _context.Category.SingleOrDefault(c=>c.Title==category.Title && c.PrentCategoryId==category.PrentCategoryId).Id;
    }

    public void UpdateCategory(Models.Category newCategory)
    {
        _context.Category.Update(newCategory);
        _context.SaveChanges();
    }
}