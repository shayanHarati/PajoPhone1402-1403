using Microsoft.AspNetCore.Mvc;
using PajoPhone.DataLayer.Interfaces;
using PajoPhone.ViewModels;

namespace PajoPhone.Controllers;

public class CategoryController : Controller
{
    private ICategory _category;

    public CategoryController(ICategory category)
    {
        _category = category;
    }
    [HttpGet]
    public IActionResult CreateOrEditCategory()
    {
        CreateOrEditCtegoryViewModel model = new CreateOrEditCtegoryViewModel()
        {
            Categories = _category.GetAllCategories().ToList()
        };
        return View(model);
    }
    
    [HttpPost]
    public IActionResult CreateOrEditCategory(CreateOrEditProductViewModel model)
    {
        return View();
    }

    
    
}