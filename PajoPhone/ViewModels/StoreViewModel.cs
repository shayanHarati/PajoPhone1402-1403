using System.ComponentModel.DataAnnotations;
using PajoPhone.Datalayer.Models;

namespace PajoPhone.ViewModels;

public class StoreViewModel
{
    public required IEnumerable<Product> Products { get; set; }
    
    [Display(Name = "نام محصول")]
    [MaxLength(100,ErrorMessage = "حداکثر طول {0} باید {1} باشد")]
    public string? ProductNameFilter { get; set; }
    
    public decimal? ProductPriceMinimumFilter { get; set; }
    
    public decimal? ProductPriceMaximumFilter { get; set; }
    
}