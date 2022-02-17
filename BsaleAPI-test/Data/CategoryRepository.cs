using BsaleAPI_test.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BsaleAPI_test.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private MySQLConfiguration _connectionString;
        public CategoryRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var db = dbConnection();

            var sql = @"
                        DELETE
                        FROM category
                        WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var db = dbConnection();

            var sql = @"
                        SELECT id, name
                        FROM category";

            return await db.QueryAsync<Category>(sql, new { });
        }

        public async Task<Category> GetCategoryDetails(int id)
        {
            var db = dbConnection();

            var sql = @"
                        SELECT id, name
                        FROM category
                        WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Category>(sql, new { Id = id });
        }

        public async Task<bool> InsertCategory(Category category)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO category (name)
                        VALUES (@Name)";

            var result = await db.ExecuteAsync(sql, new { category.Name });

            return result > 0;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE category 
                        SET name = @Name
                        WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { category.Name });

            return result > 0;
        }
    }
}
