using System.ComponentModel.DataAnnotations;
using PajoPhone.Datalayer.Models;

namespace PajoPhone.ViewModels;

public class CreateOrEditProductViewModel
{
    public Product? Product { get; set; }
    
    [Required(ErrorMessage =" {0} یک فیلد اجباری است" )]
    public  IFormFile Image { get; set; }
    public int id { get; set; }
}