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
    public List<Category> Categories { get; set; }
    
    [Display(Name = "دسته بندی والد")]
    public string SelectedCategory { get; set; }
    
}