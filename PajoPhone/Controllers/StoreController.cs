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
        model.Filter.MaxPrice = _product.GetAllProducts().Select(c => c.ProductPrice).Max();
        return View("Index",model);
    }
    public IActionResult ShowStore()
    {
        StoreViewModel model = new StoreViewModel()
        {
            Products = _product.GetAllProducts()
        };
        FilterViewModel filterModel = new FilterViewModel()
        {
            MaxPrice = _product.GetAllProducts().Select(c => c.ProductPrice).Max()
        };
        model.Filter = filterModel;
        return View("Index",model);
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
                Id = _product.GetById(id).Id,
                ProductName = _product.GetById(id).ProductName,
                ImageProduct = _product.GetById(id).ImageProduct,
                ProductColor = _product.GetById(id).ProductColor,
                ProductPrice = (_product.GetById(id).ProductPrice).ToString().Replace(",","")
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
        model.Id = model.Id;
        var product = _product.GetById(model.Id);
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
            var productmodel = new Product()
            {
                Id = model.Id,
                ProductName = model.ProductName,
                ImageProduct = model.ImageProduct,
                ProductColor = model.ProductColor,
                ProductPrice = Convert.ToDecimal(model.ProductPrice.Replace(",",""))
            };
            var extension =Path.GetExtension(model.ImageProduct);
            // if product was not in database => we want creat it
            if (product == null )
            {
                _createImage(model.Image, model.Id);
                model.ImageProduct = model.Id+ Path.GetExtension((string)model.Image.FileName);
                _product.CreateProduct(productmodel);
                
                FilterViewModel filtermodel = new FilterViewModel()
                {
                    ProductName = productmodel.ProductName,
                    ProductPriceMax = productmodel.ProductPrice,
                    ProductPriceMin = productmodel.ProductPrice,
                    MaxPrice = _product.GetAllProducts().Select(c => c.ProductPrice).Max()
                    
                };
                return RedirectToAction("Filter", filtermodel);
            }
            else
            {
                if (productmodel.ImageProduct != "p1.jpg")
                {
                   
                    var imagepath = Path.Combine("wwwroot/images/", productmodel.Id.ToString()+extension );
                    if (System.IO.File.Exists(imagepath))
                    {
                        System.IO.File.Delete(imagepath);
                    }
                }
                _createImage(model.Image,productmodel.Id);
                // if product was  in database => we want update it
                product.ImageProduct = productmodel.Id.ToString()+extension;
                product.ProductColor = productmodel.ProductColor;
                product.ProductDescription = productmodel.ProductDescription;
                product.ProductName =productmodel.ProductName;
                product.ProductPrice = productmodel.ProductPrice;
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
    public IActionResult Filter( StoreViewModel model )
    {
        var products = _product.FilterProducts(model.Filter.ProductName,
            model.Filter.ProductPriceMax, model.Filter.ProductPriceMin);
        StoreViewModel createdModel = new StoreViewModel()
        {
            Products = products,
            Filter = model.Filter,
            
        };
        return ShowStore(createdModel);
    }
}