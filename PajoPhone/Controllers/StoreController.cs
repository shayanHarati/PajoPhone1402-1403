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

    public StoreController(IProduct product)
    {
        _product = product;
    }

    public IActionResult ShowStore(StoreViewModel model)
    {
        return View("Index",model);
    }
    public IActionResult ShowStore()
    {
        StoreViewModel model = new StoreViewModel()
        {
            Products = _product.GetAllProducts()
        };
        return View("Index",model);
    }
    
    
    [HttpGet]
    public IActionResult Index()
    {
        StoreViewModel model = new StoreViewModel()
        {
            Products = _product.GetAllProducts()
        };
        return ShowStore(model);
    }
    
    [HttpGet]
    public IActionResult CreateOrEditProduct(int id)
    {
        // if product was not in database => we should create it
        if (_product.GetById(id) == null)
        {
            ViewBag.state = "افزودن محصول";
            return View();
        }
        else
        {
            // if product was  in database => we should update it
            CreateOrEditProductViewModel model = new CreateOrEditProductViewModel()
            {
                Product = _product.GetById(id)
            };
            ViewBag.state = "ویرایش محصول";
            return View(model);
        }
    }

    private static void _createImage(IFormFile Image, int id)
    {
        string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        Directory.CreateDirectory(directoryPath);

        string imagePath = Path.Combine(directoryPath,id+ Path.GetExtension(Image.FileName) );
        using (var outputStream = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
        {
            Image.CopyTo(outputStream);
        }
        
       
    }
    [HttpPost]
    public IActionResult CreateOrEditProduct(CreateOrEditProductViewModel model)
    {
        model.Product.Id = model.id;
        var product = _product.GetById(model.Product.Id);
        if (product== null)
        {
            ViewBag.state = "افزودن محصول";
        }
        else
        {
            ViewBag.state = "ویرایش محصول";
        }
        if (ModelState.IsValid)
        {
            
            // if product was not in database => we want creat it
            if (product == null )
            {
                _createImage(model.Image, model.Product.Id);
                model.Product.ImageProduct = model.Product.Id+ Path.GetExtension((string)model.Image.FileName);
                _product.CreateProduct(model.Product);
            }
            else
            {
                if (model.Product.ImageProduct != "p1.jpg")
                {
                    var imagepath = Path.Combine("wwwroot/images/", model.Product.ImageProduct);
                    if (System.IO.File.Exists(imagepath))
                    {
                        System.IO.File.Delete(imagepath);
                    }
                }
                _createImage(model.Image,model.Product.Id);
                // if product was  in database => we want update it
                product.ImageProduct = model.Image.FileName;
                product.ProductColor = model.Product.ProductColor;
                product.ProductDescription = model.Product.ProductDescription;
                product.ProductName = model.Product.ProductName;
                product.ProductPrice = model.Product.ProductPrice;
                _product.UpdateProduct(product);
            }

            return ShowStore();
        }
        // if modelstate was not valid
        
        return View(model);
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
    
    
    [HttpGet]
    public IActionResult Filter(string productName, decimal productPriceMax, decimal productPriceMin )
    {
        
        StoreViewModel model = new StoreViewModel()
        {
            ProductNameFilter = productName,
            ProductPriceMaximumFilter = productPriceMax,
            ProductPriceMinimumFilter = productPriceMin,
            Products = _product.FilterProducts(productName,productPriceMax,productPriceMin)
        };
        return ShowStore(model);
    }
}