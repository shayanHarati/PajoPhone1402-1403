using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace PajoPhone.Datalayer.Models;

public class Product
{
    public int Id { get; set; }
    
    [Display(Name = "نام محصول")]
    [Required(ErrorMessage =" {0} یک فیلد اجباری است" )]
    [MaxLength(200,ErrorMessage = "حداکثر طول {0} باید {1} باشد")]
    public required string ProductName { get; set; }
    
    [Display(Name = "توضیحات")]
    public string? ProductDescription { get; set; }
    
    [Display(Name = "رنگ محصول")]
    [Required(ErrorMessage =" {0} یک فیلد اجباری است" )]
    [MaxLength(100,ErrorMessage = "حداکثر طول {0} باید {1} باشد")]
    public required string ProductColor { get; set; }
    
    [Display(Name = "تصویر")]
    [Required(ErrorMessage =" {0} یک فیلد اجباری است" )]
    [MaxLength(200,ErrorMessage = "حداکثر طول {0} باید {1} باشد")]
    public required string ImageProduct { get; set; }
    
    [Display(Name = "قیمت محصول")]
    [Required(ErrorMessage =" {0} یک فیلد اجباری است" )]
    public decimal ProductPrice { get; set; }
    
}