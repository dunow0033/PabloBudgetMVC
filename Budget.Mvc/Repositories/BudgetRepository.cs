using System;
using System.Data;
using Budget.Mvc.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Budget.Mvc.Repositories
{
	public interface IBudgetRepository
    {
		void AddCategory(string name);
        void AddTransaction(Transaction transaction);
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
    }
}

