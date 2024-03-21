using Microsoft.AspNetCore.Mvc;
using PajoPhone.ViewModels;

namespace PajoPhone.Controllers;

public class FieldController : Controller
{
    [HttpGet]
    public IActionResult CreateField()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult CreateField(CreateFieldViewModel model)
    {
        return View();
    }
    
}