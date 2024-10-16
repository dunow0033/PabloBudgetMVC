﻿using Budget.Mvc.Models;
using Budget.Mvc.Models.ViewModels;
using Budget.Mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly IBudgetRepository _budgetRepository;

    public HomeController(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public async Task<IActionResult> Index(BudgetViewModel? model)
    {
        //var transactions = FilterTransactions(model);

        var categories = await _budgetRepository.GetCategories();

        var viewModel = new BudgetViewModel
        {
            //Transactions = transactions,
            Categories = new CategoriesViewModel { Categories = categories },
            InsertTransaction = new InsertTransactionViewModel { Categories = categories },
            FilterParameters = new FilterParametersViewModel { Categories = categories }
        };

        ModelState.Clear();

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult InsertCategory(BudgetViewModel model)
    {
        if (model.InsertCategory.Id > 0)
            _budgetRepository.UpdateCategory(model.InsertCategory.Name, model.InsertCategory.Id);
        else
            _budgetRepository.AddCategory(model.InsertCategory.Name);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult InsertTransaction(BudgetViewModel model)
    {
        var transaction = new Transaction
        {
            Id = model.InsertTransaction.Id,
            Amount = model.InsertTransaction.Amount,
            Name = model.InsertTransaction.Name,
            Date = model.InsertTransaction.Date,
            TransactionType = model.InsertTransaction.TransactionType,
            CategoryId = model.InsertTransaction.CategoryId
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

    //[AcceptVerbs("GET", "POST")]
    //public JsonResult IsUnique([Bind(Prefix = "InsertCategory.Name")] string name)
    //{
    //    var categories = _budgetRepository.GetCategories();

    //    if (categories.Any(x => x.Name == name))
    //        return Json("Category already exists");

    //    return Json(true);

    //}

    //private List<Transaction> FilterTransactions(BudgetViewModel? model)
    //{
    //    var transactions = _budgetRepository.GetTransactions();

    //    if (model.FilterParameters == null)
    //        transactions = transactions.ToList();

    //    else if ((model.FilterParameters.CategoryId != 0 && model.FilterParameters.StartDate == null))
    //        transactions = transactions
    //            .Where(x => x.CategoryId == model.FilterParameters.CategoryId)
    //            .ToList();

    //    else if ((model.FilterParameters.CategoryId == 0 && model.FilterParameters.StartDate != null))
    //        transactions = transactions
    //            .Where(x =>
    //            DateTime.Parse(x.Date) >= DateTime.Parse(model.FilterParameters.StartDate) &&
    //            DateTime.Parse(x.Date) <= DateTime.Parse(model.FilterParameters.EndDate))
    //            .ToList();

    //    else if ((model.FilterParameters.CategoryId != 0 && model.FilterParameters.StartDate != null))
    //        transactions = transactions
    //                 .Where(x =>
    //                 DateTime.Parse(x.Date) >= DateTime.Parse(model.FilterParameters.StartDate) &&
    //                 DateTime.Parse(x.Date) <= DateTime.Parse(model.FilterParameters.EndDate) &&
    //                 x.CategoryId == model.FilterParameters.CategoryId)
    //                 .ToList();

    //    return transactions;
    //}


}
