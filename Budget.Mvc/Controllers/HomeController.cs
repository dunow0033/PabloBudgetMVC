using System.Net.Mime;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
         return View();
    }

    [HttpPost]
    public IActionResult AddCategory(string name)
    {
        return Json(new { Response = "Ok" });
    }
}

public class TransactionTest
{
    public int Id { get; set; }
}