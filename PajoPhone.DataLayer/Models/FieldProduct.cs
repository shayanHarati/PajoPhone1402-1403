using PajoPhone.Datalayer.Models;

namespace PajoPhone.DataLayer.Models;

public class FieldProduct
{
    public int Id { get; set; }
    public virtual Field Field { get; set; }
    public virtual Product Product { get; set; }

    public int ProductId { get; set; }
    public int FieldId { get; set; }
}