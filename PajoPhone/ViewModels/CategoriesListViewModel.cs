using PajoPhone.DataLayer.Models;

namespace PajoPhone.ViewModels;

public class CategoriesListViewModel
{
    public CategoriesListViewModel()
    {
        Categories = new List<Category>();
        SelectedCategories = new List<int>();
    }

    public List<Category>? Categories { get; set; }
    public List<int> SelectedCategories { get; set; }
    
}