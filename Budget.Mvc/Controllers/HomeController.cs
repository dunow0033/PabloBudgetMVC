using Budget.Mvc.Models;
using Budget.Mvc.Models.ViewModels;
using Budget.Mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBudgetRepository _budgetRepository;

    public HomeController(ILogger<HomeController> logger, IBudgetRepository budgetRepository )
    {
        _logger = logger;
        _budgetRepository = budgetRepository;
    }

    public IActionResult Index()
    {
        var transactions = _budgetRepository.GetTransactions();
        var categories = _budgetRepository.GetCategories();

        var model = new TransactionViewModel
        {
            Categories = categories,
            Transactions = transactions
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult AddCategory(string name)
    {
        return Json(new { Response = "Ok" });
    }

    [HttpPost]
    public IActionResult InsertCategory(TransactionViewModel model)
    {
        _budgetRepository.AddCategory(model.Category.Name);

        return Json(new { Response = "Ok" });
    }

    [HttpPost]
    public IActionResult InsertTransaction(TransactionViewModel model)
    {
        var transaction = new Transaction
        {
            Amount = model.Amount,
            Name = model.Name,
            Date = model.Date,
            TransactionType = model.TransactionType,
            CategoryId = model.CategoryId
        };

        _budgetRepository.AddTransaction(transaction);

        return Json(new { Response = "Ok" });
    }

    [HttpPost]
    public IActionResult DeleteTransaction(int id)
    {
       

       _budgetRepository.DeleteTransaction(id);

        return Json(new { Response = "Ok" });
    }

    public ActionResult PrepareTransactionForm()
    {
        var model = new TransactionViewModel
        {
            Categories = new List<Category>
            {
                new Category { Id = 1, Name ="Groceries"},
                new Category { Id = 1, Name ="Fuel"}
            }
        };
        return PartialView("InsertTransaction", model);
    }
}

public class TransactionTest
{
    public int Id { get; set; }
}