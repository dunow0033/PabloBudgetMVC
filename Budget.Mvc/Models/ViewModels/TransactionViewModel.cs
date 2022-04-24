using System.ComponentModel.DataAnnotations;
using Budget.Mvc.Models.DTOs;

namespace Budget.Mvc.Models.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Amount { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        public List<Category>? Categories { get; set; }

        public List<TransactionWithCategory>? Transactions { get; set; }

        public Category Category { get; set;  }
        public Transaction Transaction { get; set; }
    }
}

