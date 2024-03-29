using System.ComponentModel.DataAnnotations;
using PajoPhone.DataLayer.Models;

namespace PajoPhone.ViewModels;

public class CreateOrEditCtegoryViewModel
{
    public CreateOrEditCtegoryViewModel()
    {
        Categories = new List<Category>();
    }
    [Display(Name = "عنوان دسته")]
    [Required(ErrorMessage = "{0} این فیلد ضروری است")]
    public string CategoryTitle { get; set; }
    public List<Category>? Categories { get; set; }
    
    [Required(ErrorMessage = "لطفا حداقل یک دسته بندی را انتخاب کنید")]
    

    public List<int> SelectedCategories { get; set; }
    
    
    
}