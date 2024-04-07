using System.ComponentModel.DataAnnotations;
using PajoPhone.DataLayer.Models;

namespace PajoPhone.ViewModels;

public class CreateOrEditCtegoryViewModel
{
    public CreateOrEditCtegoryViewModel()
    {
        Fields = new CreateFieldViewModel();
        CategoryList = new CategoriesListViewModel();
    }

    public int CategoryId { get; set; }
    [Display(Name = "عنوان دسته")]
    [Required(ErrorMessage = "{0} این فیلد ضروری است")]
    public string CategoryTitle { get; set; }

    public CategoriesListViewModel CategoryList { get; set; }
    
    [Required(ErrorMessage = "لطفا حداقل یک دسته بندی را انتخاب کنید")]

    public CreateFieldViewModel Fields { get; set; }
    
    
    
    
}