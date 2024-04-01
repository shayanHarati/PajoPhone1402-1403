using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PajoPhone.DataLayer.Interfaces;
using PajoPhone.ViewModels;
using Product = PajoPhone.Datalayer.Models.Product;

namespace PajoPhone.Controllers;

public class StoreController : Controller
{
    private readonly IProduct _product;
    private readonly ICategory _category;
    public StoreController(IProduct product,ICategory category)
    {
        _product = product;
        _category = category;
    }

    public IActionResult ShowStore(StoreViewModel model)
    {
        model.Filter.ProductPriceMax = _product.GetAllProducts().Select(c => c.ProductPrice).Max();
        model.Filter.ProductPriceMin = _product.GetAllProducts().Select(c => c.ProductPrice).Min();
        model.Filter.Categories = _category.GetAllCategories().ToList();
        return View("Index",model);
    }
    public IActionResult ShowStore()
    {
        StoreViewModel model = new StoreViewModel()
        {
            Products = _product.GetAllProducts(),
        };
       
        FilterViewModel filterModel = new FilterViewModel()
        {
            ProductPriceMax = _product.GetAllProducts().Select(c => c.ProductPrice).Max(),
            ProductPriceMin =  _product.GetAllProducts().Select(c => c.ProductPrice).Min(),
            Categories = _category.GetAllCategories().ToList()
        };
        model.Filter = filterModel;
        return View("Index",model);
    }

    private IActionResult showCreateOrEdit(CreateOrEditProductViewModel model)
    {
        CreateOrEditProductViewModel vm = new CreateOrEditProductViewModel()
        {
            ProductName = model.ProductName,
            ProductPrice = model.ProductPrice,
            ImageProduct = model.ImageProduct,
            ProductColor = model.ProductColor,
            ProductDescription = model.ProductDescription,
            Image = model.Image
        };
        return View("CreateOrEditProduct",vm);
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        StoreViewModel model = new StoreViewModel()
        {
            Products = _product.GetAllProducts()
        };
        return ShowStore();
    }
    
    [HttpGet]
    public IActionResult CreateOrEditProduct(int pid)
    {
        // if product was not in database => we should create it
        if (_product.GetById(pid) == null)
        {
            ViewBag.state = "افزودن محصول";
            CreateOrEditProductViewModel model = new CreateOrEditProductViewModel();
            return showCreateOrEdit(model);
        }
        else
        {
            // if product was  in database => we should update it
            CreateOrEditProductViewModel model = new CreateOrEditProductViewModel()
            {
                Id = _product.GetById(pid).Id,
                ProductName = _product.GetById(pid).ProductName,
                ImageProduct = _product.GetById(pid).ImageProduct,
                ProductColor = _product.GetById(pid).ProductColor,
                ProductDescription = _product.GetById(pid).ProductDescription,
                ProductPrice = (_product.GetById(pid).ProductPrice).ToString().Replace(",","")
            };
            ViewBag.state = "ویرایش محصول";
            return View(model);
        }
    }

    private static string _createImage(IFormFile Image, int id)
    {
        string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        Directory.CreateDirectory(directoryPath);
        string imageName = id + Path.GetExtension(Image.FileName);
        string imagePath = Path.Combine(directoryPath,imageName );
        using (var outputStream = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
        {
            Image.CopyTo(outputStream);
        }

        return imageName;

    }

    private void _removeImage(string imageName)
    {
        string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        string imagePath = Path.Combine(directoryPath,imageName );
        System.IO.File.Delete(imagePath);
    }
    [HttpPost]
    public IActionResult CreateOrEditProduct(CreateOrEditProductViewModel model)
    {
        var product = _product.GetById(model.Id);
        if (product == null)
        {
            ViewBag.state = "افزودن محصول";
        }
        else
        {
            ViewBag.state = "ویرایش محصول";
        }
        if (!ModelState.IsValid)
        {
            return showCreateOrEdit(model);
        }
        if (_product.ExistProduct(model.ProductName) && _product.GetIdByName(model.ProductName)!= model.Id)
        {
            ModelState.AddModelError("ProductName","محصولی با این نام قبلا ایجاد شده است");
            return showCreateOrEdit(model);
        }
        
        const string defaultImageName = "Default.jpg";
        // we want create a product
        if (product == null)
        {
            product = new Product()
            {
                ProductName = model.ProductName,
                ProductPrice = Convert.ToDecimal(model.ProductPrice),
                ProductColor = model.ProductColor,
                ProductDescription = model.ProductDescription,
                ImageProduct = defaultImageName,
                CategoryId = 1
            };
            var  id= _product.CreateProduct(product);
            var imageName=_createImage(model.Image,id);
            product.ImageProduct = imageName;
            model.ImageProduct = imageName;
            _product.UpdateProduct(product);
            

            FilterViewModel vm = new FilterViewModel();
            vm.ProductName = model.ProductName;
            vm.ProductPriceMax = _product.GetAllProducts().Select(c => c.ProductPrice).Max();
            vm.ProductPriceMin =  _product.GetAllProducts().Select(c => c.ProductPrice).Min();
            return RedirectToAction("Filter",vm);
        }
        else
        {
            
            ViewBag.state = "ویرایش محصول";
            var imageName = defaultImageName;
            // we want update product
            if (!(model.ImageProduct == defaultImageName))
            {
                _removeImage(model.ImageProduct);
                imageName= _createImage(model.Image, model.Id);
            }
            else if(!(model.Image.FileName == defaultImageName))
            {
                imageName= _createImage(model.Image, model.Id);
            }

            product.Id = model.Id;
            product.ProductName = model.ProductName;
            product.ProductPrice = Convert.ToDecimal(model.ProductPrice);
            product.ProductColor = model.ProductColor;
            product.ProductDescription = model.ProductDescription;
            product.ImageProduct = imageName;
            _product.UpdateProduct(product);
            return ShowStore();
        }
        
    }
    
    [HttpGet]
    public IActionResult EditProductPrice(int id)
    {
        var product = _product.GetById(id);
        return View(product);
    }
    
    [HttpPost]
    public IActionResult EditProductPrice(decimal productPrice, int id)
    {
        var selectedProduct=_product.GetById(id);
        selectedProduct.ProductPrice = productPrice;
        _product.UpdateProduct(selectedProduct);
        return ShowStore();
    }

    private StoreViewModel Search(FilterViewModel model)
    {
        var products = _product.FilterProducts(model.ProductName,
            model.ProductPriceMax, model.ProductPriceMin);
        StoreViewModel createdModel = new StoreViewModel()
        {
            Products = products,
            Filter = model,
            
        };
        return createdModel;
    }
    [HttpGet]
    public IActionResult AJaxFilter(FilterViewModel model)
    {
        return Json(Search(model));

    }
    [HttpGet]
    public IActionResult Filter( FilterViewModel model )
    {
        return ShowStore(Search(model));
    }
}