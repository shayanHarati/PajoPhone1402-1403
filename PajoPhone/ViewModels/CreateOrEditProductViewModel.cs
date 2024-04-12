using System.ComponentModel.DataAnnotations;
using PajoPhone.Datalayer.Models;
using PajoPhone.DataLayer.Models;

namespace PajoPhone.ViewModels;

public class CreateOrEditProductViewModel
{
    public CreateOrEditProductViewModel()
    {
        CategoryList = new CategoriesListViewModel();
        Dynamics = new List<FieldProduct>();
    }
    public int Id { get; set; }
    
    [Display(Name = "نام محصول")]
    [Required(ErrorMessage =" {0} یک فیلد اجباری است" )]
    [MaxLength(200,ErrorMessage = "حداکثر طول {0} باید {1} باشد")]
    public  string ProductName { get; set; }
    
    [Display(Name = "توضیحات")]
    public string? ProductDescription { get; set; }
    
    [Display(Name = "رنگ محصول")]
    [Required(ErrorMessage =" {0} یک فیلد اجباری است" )]
    [MaxLength(100,ErrorMessage = "حداکثر طول {0} باید {1} باشد")]
    public string ProductColor { get; set; }
    
    
    [Required(ErrorMessage =" {0} یک فیلد اجباری است" )]
    [MaxLength(200,ErrorMessage = "حداکثر طول {0} باید {1} باشد")]
    public string ImageProduct { get; set; }
    
    [Display(Name = "قیمت محصول")]
    [Required(ErrorMessage =" {0} یک فیلد اجباری است" )]
    [RegularExpression(@"(([0-9]{1,3})$)|(([0-9]{1,3}){0,1},([0-9]{3},)*([0-9]{3})(\.(0)+){0,1}$)|((([0-9])+))((\.(0)+){0,1})$",ErrorMessage = "مقدار نامعتبر است")]
    public string ProductPrice { get; set; }
    
    
    [Display(Name = "تصویر")]
    [Required(ErrorMessage =" {0} یک فیلد اجباری است" )]
    public  IFormFile Image { get; set; }

    public CategoriesListViewModel CategoryList { set; get; }
    public List<FieldProduct> Dynamics { get; set; }
}