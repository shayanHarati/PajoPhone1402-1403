using Microsoft.EntityFrameworkCore;
using PajoPhone.DataLayer.Models;

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

    public bool ExistField(string title)
    {
        return _context.Fields.Any(c => c.FieldTitle == title);
    }

    public IEnumerable<Models.Field> GetFieldOfCategory(List<int> ids)
    {
        List<Models.Field> fields = new List<Models.Field>();
        foreach (var id in ids)
        {
            var fieldsList=_context.Fields.Where(c => c.CategoryId == id).ToList();
            foreach (var field in fieldsList)
            {
                var Field = new Models.Field()
                {
                    FieldTitle = field.FieldTitle,
                    Id = field.Id,
                    Type = field.Type,
                    CategoryId = field.CategoryId
                };
                fields.Add(Field);
            }
        }

        return fields;
    }

    public Models.Field GetFieldById(int id)
    {
        return _context.Fields.SingleOrDefault(c => c.Id == id);
    }

    public void CreateFieldProduct(FieldProduct field)
    {
        _context.FieldProducts.Add(field);
        _context.SaveChanges();
    }

    public IEnumerable<FieldProduct> GetFieldsProduct(int id)
    {
        return _context.FieldProducts.Where(c => c.ProductId == id);
    }
}