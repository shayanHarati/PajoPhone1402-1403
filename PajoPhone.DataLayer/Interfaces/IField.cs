using PajoPhone.DataLayer.Models;

namespace PajoPhone.DataLayer.Interfaces;

public interface IField
{
    IEnumerable<Models.Field> GetAllField();
    void CreateField(Models.Field field);
}