using System.ComponentModel.DataAnnotations;
using PajoPhone.Datalayer.Models;

namespace PajoPhone.ViewModels;

public class StoreViewModel
{
    public required IEnumerable<Product> Products { get; set; }

    public FilterViewModel?  Filter { get; set; }
    
}