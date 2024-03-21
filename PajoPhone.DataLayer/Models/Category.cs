using PajoPhone.Datalayer.Models;

namespace PajoPhone.DataLayer.Models;

public class Category
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? PrentCategoryId { get; set; }
    
    #region Relations
    public virtual List<Product> Products { get; set; }
    public virtual List<Field> Fields { get; set; }
    #endregion
    
}