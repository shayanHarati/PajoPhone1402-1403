using Microsoft.AspNetCore.Mvc;
using PajoPhone.DataLayer.Interfaces;
using PajoPhone.ViewModels;
using Category = PajoPhone.DataLayer.Models.Category;
using Field = PajoPhone.DataLayer.Models.Field;

namespace PajoPhone.Controllers;

public class CategoryController : Controller
{
    private ICategory _category;
    private IField _field;
    public CategoryController(ICategory category,IField field)
    {
        _category = category;
        _field = field;
    }

    private IActionResult showCreateCategoryForm()
    {
        return RedirectToAction("CreateOrEditCategory");
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
    public IActionResult CreateOrEditCategory(CreateOrEditCtegoryViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return showCreateCategoryForm();
        }
        var category = _category.GetCategory(model.CategoryId);
        // Category should be created
        if (category == null)
        {
            if (model.SelectedCategories.Count ==0)
            {
                category = new Category()
                {
                    Level = 0,
                    Title = model.CategoryTitle,
                };
                var catId= _category.CreateCategory(category);
                foreach (var fieldObj in model.Fields.Fields)
                {
                    var field = new Field()
                    {
                        FieldTitle = fieldObj.FieldTitle,
                        CategoryId = catId,
                        Type = fieldObj.Type
                    };
                    _field.CreateField(field);
                }
            }
            foreach (var sub in model.SelectedCategories)
            {
                var parentLevel = _category.GetLevel(sub);
                category = new Category()
                {
                    Level = parentLevel + 1,
                    Title = model.CategoryTitle,
                    PrentCategoryId = sub.ToString()
                };
                var catId= _category.CreateCategory(category);
                foreach (var fieldObj in model.Fields.Fields)
                {
                    var field = new Field()
                    {
                        FieldTitle = fieldObj.FieldTitle,
                        CategoryId = catId,
                        Type = fieldObj.Type
                    };
                    _field.CreateField(field);
                }
            }
           
            return Redirect($"/Store/Index/");
        }
        else
        {
            // Category should be Updated
            return Redirect($"/Store/Index/");
        }
    }

    
    
}