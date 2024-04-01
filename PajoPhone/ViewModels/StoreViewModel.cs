using System.ComponentModel.DataAnnotations;
using PajoPhone.Datalayer.Models;
using PajoPhone.DataLayer.Models;

namespace PajoPhone.ViewModels;

public class StoreViewModel
{
    public StoreViewModel()
    {
        Filter = new FilterViewModel();
    }
    public  IEnumerable<Product>? Products { get; set; }

    public FilterViewModel?  Filter { get; set; }
    
    
    
    
}