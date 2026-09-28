using Microsoft.AspNetCore.Mvc;
using Nicole.Data;
using Nicole.Models;

namespace Nicole.Controllers;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _db;

    public ProductsController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var products = _db.Products.ToList();
        return View(products);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        _db.Products.Add(product);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
