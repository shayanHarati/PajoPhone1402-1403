using PajoPhone.DataLayer.Models;
namespace PajoPhone.ViewModels;

public class CreateFieldViewModel
{
    public CreateFieldViewModel()
    {
        Fields = new List<Field>()
        {
            new Field()
        };
    }
    public List<Field> Fields { get; set; }
}