using System.ComponentModel.DataAnnotations;
using PajoPhone.DataLayer.Models;

namespace PajoPhone.ViewModels;

public class FilterViewModel
{
    public FilterViewModel()
    {
        Fields = new List<Field>();
        SelectedFields = new List<string>();
        CategoryList = new CategoriesListViewModel();
    }
    [Display(Name = "نام محصول")]
    [MaxLength(100,ErrorMessage = "حداکثر طول {0} باید {1} باشد")]
    public string? ProductName { get; set; }
    public decimal ProductPriceMax { get; set; }
    public decimal ProductPriceMin { get; set; }
    public CategoriesListViewModel CategoryList { get; set; }
    public  List<Field> Fields { get; set; }
    public List<string>? SelectedFields { get; set; }
    
}