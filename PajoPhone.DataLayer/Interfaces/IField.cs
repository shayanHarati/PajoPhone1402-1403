using PajoPhone.DataLayer.Models;

namespace PajoPhone.DataLayer.Interfaces;

public interface IField
{
    IEnumerable<Models.Field> GetAllField();
    void CreateField(Models.Field field);
    bool ExistField(string title);
    IEnumerable<Models.Field> GetFieldOfCategory(List<int> id);
    Models.Field GetFieldById(int id);
    void CreateFieldProduct(FieldProduct field);
    IEnumerable<Models.FieldProduct> GetFieldsProduct(int id);
}