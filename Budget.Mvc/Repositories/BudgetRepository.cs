using System.Data;
using Budget.Mvc.Models;
using Budget.Mvc.Models.DTOs;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Budget.Mvc.Repositories
{
	public interface IBudgetRepository
    {
        List<Category> GetCategories();
        void AddCategory(string name);
        
        List<TransactionWithCategory> GetTransactions();
        void AddTransaction(Transaction transaction);
        void DeleteTransaction(int id);
      
        
    }
	public class BudgetRepository: IBudgetRepository
	{
		private readonly IConfiguration _configuration;

		public BudgetRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}

        public void AddCategory(string name)
        {
            try
            {
                using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    var sql = "INSERT INTO Category(Name) Values(@Name)";
                    connection.Execute(sql, new { Name = name });
                }
            }
            catch (Exception ex)
            {
                // do something;
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            try
            {
                using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    var sql = "INSERT INTO Transactions(Name, Date, TransactionType, CategoryId ) Values(@Name, @Date, @TransactionType, @CategoryId )";
                    connection.Execute(sql, transaction );
                }
            }
            catch (Exception ex)
            {
                // do something;
            }
        }

        public void DeleteTransaction(int id)
        {
            try
            {
                using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    var sql = "DELETE FROM Transactions WHERE Id = @id";
                    connection.Execute(sql, new { id });
                }
            }
            catch (Exception ex)
            {
                // do something;
            }
        }

        public List<Category> GetCategories()
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var query = @"SELECT * FROM Category";

                var categories = connection.Query<Category>(query).ToList();

                return categories;
            }
        }

        public List<TransactionWithCategory> GetTransactions()
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var query =
                    @"SELECT t.Amount, t.CategoryId, t.[Date], t.Id, t.TransactionType, t.Name, c.Name AS Category
                      FROM Transactions AS t
                      LEFT JOIN Category AS c
                      ON t.CategoryId = c.Id;";

                var allTransactions = connection.Query<TransactionWithCategory>(query);

                return allTransactions.ToList();
            }
        }
    }
}

