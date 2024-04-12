using Microsoft.AspNetCore.Mvc;
using PajoPhone.DataLayer.Interfaces;
using PajoPhone.ViewModels;

namespace PajoPhone.Controllers;

public class FieldController : Controller
{
    private IField _field;
    private ICategory _category;
    public FieldController(IField field,ICategory category)
    {
        _field = field;
        _category = category;
    }
    [HttpGet]
    public IActionResult GetAllFields(int id)
    {
        var sub = _category.GetIdsOfParents(id);
        var model = new FieldsViewModel()
        {
            DynamicFields = _field.GetFieldOfCategory(sub).ToList()
        };
        return Json(model);
    }
    
    
    
}