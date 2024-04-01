using System.ComponentModel.DataAnnotations;
using PajoPhone.DataLayer.Models;

namespace PajoPhone.ViewModels;

public class FilterViewModel
{
    public FilterViewModel()
    {
        Fields = new List<string>();
        Categories = new List<Category>();
        SelectedCategories = new List<string>();
        SelectedFields = new List<string>();

    }
    [Display(Name = "نام محصول")]
    [MaxLength(100,ErrorMessage = "حداکثر طول {0} باید {1} باشد")]
    public string? ProductName { get; set; }
    public decimal ProductPriceMax { get; set; }
    public decimal ProductPriceMin { get; set; }
    public bool AllCategories { get; set; }
    public  List<Category> Categories { get; set; }
    public List<string>? SelectedCategories { get; set; }
    
    public  List<string> Fields { get; set; }
    public List<string>? SelectedFields { get; set; }
    
}