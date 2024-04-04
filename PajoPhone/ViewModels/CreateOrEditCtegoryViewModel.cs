using System.ComponentModel.DataAnnotations;
using PajoPhone.DataLayer.Models;

namespace PajoPhone.ViewModels;

public class CreateOrEditCtegoryViewModel
{
    public CreateOrEditCtegoryViewModel()
    {
        Fields = new CreateFieldViewModel();
        CategoriesList = new CategoriesListViewModel();
        SelectedCategories = new List<int>();
    }

    public int CategoryId { get; set; }
    [Display(Name = "عنوان دسته")]
    [Required(ErrorMessage = "{0} این فیلد ضروری است")]
    public string CategoryTitle { get; set; }

    public CategoriesListViewModel CategoriesList { get; set; }
    public List<int> SelectedCategories { get; set; }
    
    [Required(ErrorMessage = "لطفا حداقل یک دسته بندی را انتخاب کنید")]

    public CreateFieldViewModel Fields { get; set; }
    
    
    
    
}