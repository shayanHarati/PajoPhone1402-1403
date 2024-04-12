using PajoPhone.DataLayer.Models;

namespace PajoPhone.ViewModels;

public class FieldsViewModel
{
    public FieldsViewModel()
    {
        DynamicFields = new List<Field>();
    }

    public List<Field> DynamicFields { get; set; }
}