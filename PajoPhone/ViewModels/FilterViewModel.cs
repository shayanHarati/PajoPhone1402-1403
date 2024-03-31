using System.ComponentModel.DataAnnotations;

namespace PajoPhone.ViewModels;

public class FilterViewModel
{
    [Display(Name = "نام محصول")]
    [MaxLength(100,ErrorMessage = "حداکثر طول {0} باید {1} باشد")]
    public string? ProductName { get; set; }
    public decimal ProductPriceMax { get; set; }
    public decimal ProductPriceMin { get; set; }
    
    
}