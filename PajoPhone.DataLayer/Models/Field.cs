namespace PajoPhone.DataLayer.Models;

public enum FieldType
{
  String,
  Money,
  Number,
  DateTime
}

public class Field
{
    public int Id { get; set; }
    public FieldType Type { get; set; }

    #region Relations
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public virtual List<FieldProduct> Products { get; set; }
    #endregion
}