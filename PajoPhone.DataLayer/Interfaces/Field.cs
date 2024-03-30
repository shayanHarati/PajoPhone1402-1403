namespace PajoPhone.DataLayer.Interfaces;

public class Field:IField
{
    private Context _context;
    public Field(Context context)
    {
        _context = context;
    }
    public IEnumerable<Models.Field> GetAllField()
    {
        return _context.Fields;
    }

    public void CreateField(Models.Field field)
    {
        _context.Fields.Add(field);
        _context.SaveChanges();
    }
}