
namespace Budget.Mvc.Models.DTOs
{
    public class TransactionWithCategory
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}

