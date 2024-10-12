using System.Data;
using Budget.Mvc.Data;
using Budget.Mvc.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Budget.Mvc.Repositories
{
    public interface IBudgetRepository
    {
        Task<List<Category>> GetCategories();
        void AddCategory(string name);
        void DeleteCategory(int id);
        void UpdateCategory(string name, int id);

        Task<List<Transaction>> GetTransactions();
        void AddTransaction(Transaction transaction);
        void DeleteTransaction(int id);
        void UpdateTransaction(Transaction transaction);


    }
    public class BudgetRepository : IBudgetRepository
    {
        private readonly IConfiguration configuration;
        private readonly BudgetDbContext budgetDbContext;

        public BudgetRepository(BudgetDbContext budgetDbContext, IConfiguration configuration)
        {
            this.budgetDbContext = budgetDbContext;
            this.configuration = configuration;
        }

        public void AddCategory(string name)
        {
            //using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            //{
            //    var sql = "INSERT INTO Category(Name) Values(@Name)";
            //    connection.Execute(sql, new { Name = name });
            //}

        }

        public void AddTransaction(Transaction transaction)
        {
            //using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            //{
            //    var sql = "INSERT INTO Transactions(Name, Date, Amount, TransactionType, CategoryId ) Values(@Name, @Date, @Amount, @TransactionType, @CategoryId )";
            //    connection.Execute(sql, transaction);
            //}
        }

        public void DeleteTransaction(int id)
        {
            //using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            //{
            //    var sql = "DELETE FROM Transactions WHERE Id = @id";
            //    connection.Execute(sql, new { id });
            //}
        }

        public void DeleteCategory(int id)
        {
            //using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            //{
            //    var sql = "DELETE FROM Category WHERE Id = @id";
            //    connection.Execute(sql, new { id });
            //}
        }

        public async Task<List<Category>> GetCategories()
        {
            return await budgetDbContext.Categories.ToListAsync();
        }

        public async Task<List<Transaction>> GetTransactions()
        {
            return await budgetDbContext.Transactions.ToListAsync();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            //using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            //{
            //    var sql =
            //        @"UPDATE Transactions
            //              SET Date = @Date, Amount = @Amount, Name = @Name, CategoryId = @CategoryId, TransactionType = @TransactionType
            //              WHERE Id = @Id";

            //    connection.Execute(sql, transaction);
            //}
        }

        public void UpdateCategory(string name, int id)
        {
            //using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            //{
            //    var sql =
            //        "UPDATE Category SET Name = @Name WHERE Id = @Id";

            //    connection.Execute(sql, new { Name = name, Id = id });
            //}
        }
    }
}

