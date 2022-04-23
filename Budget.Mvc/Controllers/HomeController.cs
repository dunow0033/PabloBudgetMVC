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
        var list = new List<TransactionTest>
        {
            new TransactionTest { Id = 1 },
            new TransactionTest { Id = 2}
        };
        return View(list);
    }

    public IActionResult AddTransaction(int id)
    {
        var list = new List<TransactionTest>
        {
            new TransactionTest { Id = 1 },
            new TransactionTest { Id = 2 }
        };

        var model = list.Where(m => m.Id == id).FirstOrDefault();

        return PartialView("_addTransaction", model);
    }
}

public class TransactionTest
{
    public int Id { get; set; }
}