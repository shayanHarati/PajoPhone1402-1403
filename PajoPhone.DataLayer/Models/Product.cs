using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PajoPhone.DataLayer.Models;

namespace PajoPhone.Datalayer.Models;

public class Product
{
    public int Id { get; set; }
    
    [MaxLength(200,ErrorMessage = "حداکثر طول {0} باید {1} باشد")]
    public required string ProductName { get; set; }
    public string? ProductDescription { get; set; }
    
    [MaxLength(100,ErrorMessage = "حداکثر طول {0} باید {1} باشد")]
    public required string ProductColor { get; set; }
    
    [MaxLength(200,ErrorMessage = "حداکثر طول {0} باید {1} باشد")]
    public required string ImageProduct { get; set; }
    public decimal ProductPrice { get; set; }

    #region 
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public virtual List<FieldProduct> Fields { get; set; }
    #endregion
    
}