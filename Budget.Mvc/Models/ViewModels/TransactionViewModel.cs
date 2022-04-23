using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Budget.Mvc.Models.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public TransactionType TransactionType { get; set; }
        public Category Category { get; set; }
    }
}

