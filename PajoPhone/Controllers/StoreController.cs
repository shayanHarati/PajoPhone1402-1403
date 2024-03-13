using Microsoft.AspNetCore.Mvc;

namespace PajoPhone.Controllers;

public class StoreController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}