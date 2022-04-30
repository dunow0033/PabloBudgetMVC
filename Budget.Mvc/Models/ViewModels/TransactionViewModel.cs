using System.ComponentModel;
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
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Type")]
        public TransactionType TransactionType { get; set; }

        public List<Category>? Categories { get; set; }

        public List<TransactionWithCategory>? Transactions { get; set; }

        public Category Category { get; set;  }
        public Transaction Transaction { get; set; }

        public SearchParameters? SearchParameters { get; set; }
    }

    public class SearchParameters
    {
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Start Date")]
        public string StartDate { get; set; }

        [DisplayName("End Date")]
        public string EndDate { get; set; }
    }
}

