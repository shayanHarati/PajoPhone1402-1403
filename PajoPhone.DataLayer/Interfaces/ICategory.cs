using PajoPhone.DataLayer.Models;

namespace PajoPhone.DataLayer.Interfaces;

public interface ICategory
{
    IEnumerable<Models.Category> GetAllCategories();
    Models.Category GetCategory(int id);
    int GetLevel(int id);
    int CreateCategory(Models.Category category);
    void UpdateCategory(Models.Category newCategory);
}