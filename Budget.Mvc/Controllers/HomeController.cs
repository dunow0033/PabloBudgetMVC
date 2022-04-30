using Budget.Mvc.Models;
using Budget.Mvc.Models.DTOs;
using Budget.Mvc.Models.ViewModels;
using Budget.Mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBudgetRepository _budgetRepository;

    public HomeController(ILogger<HomeController> logger, IBudgetRepository budgetRepository)
    {
        _logger = logger;
        _budgetRepository = budgetRepository;
    }

    public IActionResult Index(TransactionViewModel? model)
    {
        var transactions = FilterTransactions(model);

        var categories = _budgetRepository.GetCategories();

        var viewModel = new TransactionViewModel
        {
            Transactions = transactions,
            Categories = categories
        };

        ModelState.Clear();

        return View(viewModel);
    }

    private List<TransactionWithCategory> FilterTransactions(TransactionViewModel? model)
    {
        var transactions = _budgetRepository.GetTransactions();

        if (model.SearchParameters == null)
            transactions = transactions.ToList();

        else if ((model.SearchParameters.CategoryId != 0 && model.SearchParameters.StartDate == null))
            transactions = transactions
                .Where(x => x.CategoryId == model.SearchParameters.CategoryId)
                .ToList();

        else if ((model.SearchParameters.CategoryId == 0 && model.SearchParameters.StartDate != null))
            transactions = transactions
                .Where(x => DateTime.Parse(x.Date) >= DateTime.Parse(model.SearchParameters.StartDate) && DateTime.Parse(x.Date) <= DateTime.Parse(model.SearchParameters.EndDate))
                .ToList();

        else if ((model.SearchParameters.CategoryId != 0 && model.SearchParameters.StartDate != null))
            transactions = transactions
                     .Where(x => DateTime.Parse(x.Date) >= DateTime.Parse(model.SearchParameters.StartDate) && DateTime.Parse(x.Date) <= DateTime.Parse(model.SearchParameters.EndDate) && x.CategoryId == model.SearchParameters.CategoryId)
                     .ToList();

        return transactions;
    }

    [HttpPost]
    public IActionResult InsertCategory(TransactionViewModel model)
    {
        if (model.Category.Id > 0)
            _budgetRepository.UpdateCategory(model.Category.Name, model.Category.Id);
        else
            _budgetRepository.AddCategory(model.Category.Name);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult InsertTransaction(TransactionViewModel model)
    {
        var transaction = new Transaction
        {
            Id = model.Id,
            Amount = model.Amount,
            Name = model.Name,
            Date = model.Date,
            TransactionType = model.TransactionType,
            CategoryId = model.CategoryId
        };

        if (transaction.Id > 0)
            _budgetRepository.UpdateTransaction(transaction);
        else
            _budgetRepository.AddTransaction(transaction);

        return RedirectToAction("Index");
    }

    public IActionResult DeleteTransaction(int id)
    {

        _budgetRepository.DeleteTransaction(id);

        return RedirectToAction("Index");
    }

    public IActionResult DeleteCategory(int id)
    {

        _budgetRepository.DeleteCategory(id);

        return RedirectToAction("Index");
    }

    [AcceptVerbs("GET", "POST")]
    public JsonResult IsUnique([Bind(Prefix = "Category.Name")] string name)
    {
        var categories = _budgetRepository.GetCategories();

        if (categories.Any(x => x.Name == name))
            return Json("Category already exists");

        return Json(true);

    }

}
