using PajoPhone.DataLayer.Models;

namespace PajoPhone.DataLayer.Interfaces;

public interface ICategory
{
    IEnumerable<Models.Category> GetAllCategories();
    void CreateCategory(Models.Category category);
    void UpdateCategory(Models.Category newCategory);
}